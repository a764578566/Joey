using SharpCompress.Common;
using SharpCompress.Writers;
using SharpCompress.Writers.GZip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoeySoft.PackageTool
{
    public partial class PackageToolFrm : Form
    {
        private string[] PackageAdresses;

        public PackageToolFrm()
        {
            PackageAdresses = ConfigurationManager.AppSettings["PackageAdresses"].Split(',');
            InitializeComponent();

            this.PackageAdressCBX.Text = PackageAdresses[0];
            this.PackageAdressCBX.Items.AddRange(PackageAdresses);

        }

        /// <summary>
        /// “获取包版本信息”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetPackageVersion_Click(object sender, EventArgs e)
        {
            List<JoeySoftVersion> joeySoftVersions = PackageUpdateService.GetVersionInfo();
            this.PackagelistBx.DataSource = joeySoftVersions;
            this.PackagelistBx.DisplayMember = nameof(JoeySoftVersion.Show);
        }

        /// <summary>
        /// “打包”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Packbtn_Click(object sender, EventArgs e)
        {
            if (this.PackagelistBx.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要打包的软件！");
                return;
            }

            JoeySoftVersion joeySoftVersion = new JoeySoftVersion();

            if (this.PackagelistBx.SelectedItem is JoeySoftVersion)
            {
                joeySoftVersion = this.PackagelistBx.SelectedItem as JoeySoftVersion;
            }
            else
            {
                MessageBox.Show("系统错误！");
                return;
            }

            if (string.IsNullOrEmpty(this.PackageAdressCBX.Text))
            {
                //选择文件夹
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = this.PackageAdressCBX.Text;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //选择的文件夹
                    this.PackageAdressCBX.Text = openFileDialog.FileName;
                }
            }

            string directoryPath = Directory.GetParent(this.PackageAdressCBX.Text).FullName;

            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(this.PackageAdressCBX.Text);
            string zipAddress = Path.Combine(Directory.GetParent(directoryPath).FullName, joeySoftVersion.JoeySoftName + "V" + myFileVersionInfo.FileVersion + ".zip");
            using (Stream stream = File.Open(zipAddress, FileMode.OpenOrCreate, FileAccess.Write))
            using (var writer = WriterFactory.Open(stream, ArchiveType.Zip, new WriterOptions(CompressionType.BZip2)
            {
                LeaveStreamOpen = true
            }))
            {
                writer.WriteAll(directoryPath, "*",
                    n => n.StartsWith(Path.Combine(directoryPath, "UpdateService")) == false
                    && n.StartsWith(Path.Combine(directoryPath, "Log")) == false
                    && n.EndsWith(".config") == false,
                    SearchOption.AllDirectories);
            }

            MessageBox.Show("打包成功！");
        }

        /// <summary>
        /// 推包到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pushbtn_Click(object sender, EventArgs e)
        {
            if (this.PackagelistBx.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要打包的软件！");
                return;
            }

            JoeySoftVersion joeySoftVersion = new JoeySoftVersion();

            if (this.PackagelistBx.SelectedItem is JoeySoftVersion)
            {
                joeySoftVersion = this.PackagelistBx.SelectedItem as JoeySoftVersion;
            }

            string directoryPath = Directory.GetParent(this.PackageAdressCBX.Text).FullName;
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(this.PackageAdressCBX.Text);
            string zipAddress = Path.Combine(Directory.GetParent(directoryPath).FullName, joeySoftVersion.JoeySoftName + "V" + myFileVersionInfo.FileVersion + ".zip");

            if (!File.Exists(zipAddress))
            {
                MessageBox.Show("先打包后，再点推送！");
            }
            //上传包

            PutPackageVersion putPackageVersion = new PutPackageVersion();
            putPackageVersion.Version = myFileVersionInfo.FileVersion;
            putPackageVersion.JoeySoftName = joeySoftVersion.JoeySoftName;
            if (PackageUpdateService.UpdateVersionInfo(putPackageVersion).StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("推包报错！");
            }
            else
            {
                MessageBox.Show("推包成功！");
            }
        }
    }
}
