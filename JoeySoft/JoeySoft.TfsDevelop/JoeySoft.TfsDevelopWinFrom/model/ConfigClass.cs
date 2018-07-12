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
        #region 更新目录
        /// <summary>
        /// 元数据文件夹
        /// </summary>
        public static string _metadata = "_metadata";

        /// <summary>
        /// 二开目录文件
        /// </summary>
        public static string customize = "Customize";

        /// <summary>
        /// 二开元数据文件夹
        /// </summary>
        public static string x_MetaData = customize + "\\x_MetaData";


        /// <summary>
        /// js文件夹名称
        /// </summary>
        public static string _clgyl = "Clgyl";
        /// <summary>
        /// bin目录
        /// </summary>
        public static string _bin = "bin";
        #endregion

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
