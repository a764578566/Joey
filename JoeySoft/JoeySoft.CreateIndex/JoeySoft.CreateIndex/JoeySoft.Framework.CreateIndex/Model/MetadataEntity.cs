using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JoeySoft.Framework.CreateIndex
{
    /// <summary>
    /// 实体XML对象
    /// </summary>
    [Serializable]
    public class MetadataEntity
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
        [XmlAttribute]
        public string Application { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 实体显示名称
        /// </summary>
        [XmlAttribute]
        public string DisplayName { get; set; }

        /// <summary>
        /// 实体GUID
        /// </summary>
        [XmlAttribute]
        public Guid EntityId { get; set; }

        /// <summary>
        /// 实体属性信息
        /// </summary>
        [XmlArray("Attributes")]
        [XmlArrayItem("MetadataAttribute")]
        public List<MetadataAttribute> Attributes { get; set; }
    }
}
