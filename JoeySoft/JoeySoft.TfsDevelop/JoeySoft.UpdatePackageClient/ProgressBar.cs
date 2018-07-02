using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoeySoft.UpdatePackageClient
{
    public partial class ProgressBar : Form
    {
        private BackgroundWorker worker; //ProcessForm 窗体事件(进度条窗体)

        public ProgressBar(BackgroundWorker worker)
        {
            InitializeComponent();
            this.worker = worker;
            this.worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("已更新为最新版本！");
            this.Invoke(new Action(() => { this.Close(); }));//执行完之后，直接关闭页面
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.progressBar1.Value = e.ProgressPercentage;
                this.Text = e.UserState.ToString();
            }));

        }

        private void ProgressBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            string joeySoftTfsToolFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JoeySoftTfsTool.exe");
            if (File.Exists(joeySoftTfsToolFilePath))
            {
                System.Diagnostics.Process.Start(joeySoftTfsToolFilePath);
            }
            else
            {
                joeySoftTfsToolFilePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)), "JoeySoftTfsTool.exe");
                if (File.Exists(joeySoftTfsToolFilePath))
                {
                    System.Diagnostics.Process.Start(joeySoftTfsToolFilePath);
                }
            }
        }
    }
}
