using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JoeySoft.Framework.CreateIndex
{
    /// <summary>
    /// 实体属性XML对象
    /// </summary>
    [Serializable]
    public class MetadataAttribute
    {
        /// <summary>
        /// 应该名称
        /// </summary>
        [XmlAttribute("metadataStatus")]
        public string MetadataStatus { get; set; }

        /// <summary>
        /// 实体属性GUID
        /// </summary>
        public Guid AttributeId { get; set; }

        /// <summary>
        /// 实体属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 实体属性显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 实体属性类型
        /// </summary>
        public string AttributeType { get; set; }

        /// <summary>
        /// 实体属性数据库类型
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// 实体属性长度
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// 实体属性是否允许为空
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 实体属性默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 实体属性顺序
        /// </summary>
        public int ColumnNumber { get; set; }

        /// <summary>
        /// 是否主键属性
        /// </summary>
        public bool IsPrimaryAttribute { get; set; }
    }
}
