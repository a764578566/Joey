using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEdit.WPF.Model
{
    public class MyApplicationConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property
        = new ConfigurationProperty(string.Empty, typeof(MyApplicationCollection), null,
                                        ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public MyApplicationCollection Items
        {
            get
            {
                return (MyApplicationCollection)base[s_property];
            }
        }
    }
}
