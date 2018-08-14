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

        /// <summary>
        /// App_Data目录
        /// </summary>
        public static string _app_Data = "App_Data";

        /// <summary>
        /// App_Data目录下文件
        /// </summary>
        public static string App_DataContainFileNames = "BuildInDesktopParts.config";
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
        public static string MetadataDirectory = "AppCard,AppForm,AppGrid,AppTreeGrid,DataSet,Entity,EntityLog,EventConfig,FunctionPage,Langs,MetadataRelationship,MyApplication,MyFunction,PagesTemplates,Param,ParamType,View";

        /// <summary>
        /// 忽略的文件
        /// </summary>
        public static string NotContainFileName = "customize-module.json,navbartools.js";

        /// <summary>
        /// 需要更新的更目录文件
        /// </summary>
        public static string RootContainFileName = "ErpInit.html,Gruntfile.js,MysoftVersion_MAP.config";
    }
}
