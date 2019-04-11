using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JoeySoft.Framework.CreateIndex
{
    /// <summary>
    /// 关联关系元数据XML对象
    /// </summary>
    [Serializable]
    public class MetadataRelationship
    {
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
        /// 关联关系GUID
        /// </summary>
        [XmlElement("RelationshipId")]
        public Guid RelationShipId { get; set; }

        /// <summary>
        /// 关联关系名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 实体对象GUID
        /// </summary>
        public Guid PrimaryEntityId { get; set; }

        /// <summary>
        /// 实体对象属性GUID
        /// </summary>
        public Guid PrimaryAttributeId { get; set; }

        /// <summary>
        /// 关联实体对象GUID
        /// </summary>
        public Guid RelatedEntityId { get; set; }

        /// <summary>
        /// 关联实体对象属性GUID
        /// </summary>
        public Guid RelatedAttributeId { get; set; }

        /// <summary>
        /// 对象关系 OneToMore OneToOne MoreToMore
        /// </summary>
        public string Type { get; set; }
    }
}
