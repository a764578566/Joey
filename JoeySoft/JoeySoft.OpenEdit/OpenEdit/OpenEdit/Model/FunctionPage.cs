using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OpenEdit.Model
{
    /// <summary>
    /// 页面数据
    /// </summary>
    [Serializable]
    [XmlRoot("functionPage")]
    public class FunctionPage
    {
        /// <summary>
        /// 实体版本
        /// </summary>
        [XmlAttribute("metadataversion")]
        public string Metadataversion { get; set; }

        /// <summary>
        /// 应该名称
        /// </summary>
        [XmlAttribute("metadataStatus")]
        public string MetadataStatus { get; set; }

        /// <summary>
        /// 应用代码 2201材料
        /// </summary>
        [XmlAttribute("application")]
        public string Application { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 战略协议材料明细Excel编制
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// 战略协议材料明细Excel编制
        /// </summary>
        [XmlAttribute("pageName")]
        public string PageName { get; set; }

        /// <summary>
        /// 是否允许编辑  不开放false 开放true
        /// </summary>
        [XmlAttribute("isAllowEdit")]
        public bool IsAllowEdit { get; set; }

        /// <summary>
        /// 开发程度 完全开放AllowAll、部分开放AllowAdd
        /// </summary>
        [XmlAttribute("editMode")]
        public string EditMode { get; set; }
    }
}
