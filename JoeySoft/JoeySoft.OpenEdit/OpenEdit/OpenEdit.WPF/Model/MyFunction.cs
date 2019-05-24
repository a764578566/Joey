using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenEdit.WPF.Model
{
    /// <summary>
    /// 菜单数据
    /// </summary>
    [Serializable]
    [XmlRoot("myFunction")]
    public class MyFunction
    {
        /// <summary>
        /// 菜单版本
        /// </summary>
        [XmlAttribute("metadataversion")]
        public string Metadataversion { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [XmlAttribute("metadataStatus")]
        public string MetadataStatus { get; set; }

        /// <summary>
        /// 应用代码 2201材料
        /// </summary>
        [XmlAttribute("application")]
        public string Application { get; set; }

        /// <summary>
        /// 菜单GUID
        /// </summary>
        [XmlAttribute("functionGuid")]
        public Guid FunctionGuid { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [XmlAttribute("functionName")]
        public string FunctionName { get; set; }

        /// <summary>
        /// 是否菜单禁用
        /// </summary>
        [XmlAttribute("isDisabled")]
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 菜单全编码
        /// </summary>
        [XmlAttribute("hierarchyCode")]
        public string HierarchyCode { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        [XmlAttribute("functionCode")]
        public string FunctionCode { get; set; }
    }
}
