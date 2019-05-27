using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEdit.WPF.Model
{
    [ConfigurationCollection(typeof(MyApplication), AddItemName = "MyApplication")]
    public class MyApplicationCollection : ConfigurationElementCollection        // 自定义一个集合
    {
        // 基本上，所有的方法都只要简单地调用基类的实现就可以了。

        public MyApplicationCollection() : base(StringComparer.OrdinalIgnoreCase)    // 忽略大小写
        {
        }

        // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
        new public MyApplication this[string name]
        {
            get
            {
                return (MyApplication)base.BaseGet(name);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyApplication();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MyApplication)element).ApplictionCode;
        }
    }
}
