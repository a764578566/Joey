using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeySoft.TfsDevelopWinFrom.model
{
    /// <summary>
    /// 静态配置文件
    /// </summary>
    public static class ConfigClass
    {
        /// <summary>
        /// 更新包的文件夹名称
        /// </summary>
        public static string UpdateServicePathName = "UpdateService";

        /// <summary>
        /// 更新包exe名称
        /// </summary>
        public static string UpdateServiceExeName = "JoeySoft.UpdatePackageClient.exe";

        /// <summary>
        /// 需要更新的文件夹
        /// </summary>
        public static string UpdateDirectory = "_base,_frontend,modeling,MyWorkflow,PubPlatform,Report,Clgyl";
        //<add key = "UpdateDirectory" value="_base,_frontend,ActiveX,dogLib,modeling,MyWorkflow,node,Plugin,PubPlatform,Report,Clgyl"/>

        /// <summary>
        /// 需要更新的元数据文件夹
        /// </summary>
        public static string MetadataDirectory = "AppForm,AppGrid,AppTreeGrid,AppCard,Entity,View,MetadataRelationship,EventConfig,FunctionPage,Langs,MyFunction";
    }
}
