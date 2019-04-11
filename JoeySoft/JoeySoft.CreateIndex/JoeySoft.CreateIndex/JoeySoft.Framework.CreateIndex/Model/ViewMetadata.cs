using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JoeySoft.Framework.CreateIndex
{
    /// <summary>
    /// 视图XML对象
    /// </summary>
    [Serializable]
    public class ViewMetadata
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
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// 实体显示名称
        /// </summary>
        [XmlAttribute("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 实体GUID
        /// </summary>
        [XmlAttribute("viewId")]
        public Guid ViewId { get; set; }


        public string DataSource { get; set; }

        [XmlArray("Attributes")]
        [XmlArrayItem("MetadataAttribute")]
        public List<ViewMetadataAttribute> Attributes { get; set; }
    }
}
