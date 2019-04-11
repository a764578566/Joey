using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JoeySoft.Framework.CreateIndex
{
    /// <summary>
    /// 视图属性XML对象
    /// </summary>
    [Serializable]
    [XmlRoot("MetadataAttribute")]
    public class ViewMetadataAttribute
    {
        /// <summary>
        /// 实体属性GUID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 实体属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 实体属性显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 是否复合主键 0否 1是
        /// </summary>
        public bool IsCompositeKey { get; set; }

        /// <summary>
        /// 实体属性数据库类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 类型全名称
        /// </summary>
        public string FullTypeName { get; set; }
    }
}
