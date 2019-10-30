using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyBrowser.structure
{
    public class PropertuNode : INode
    {
        public string Name { get; set; }
        public string TypeName { get; set; }

        public PropertuNode(PropertyInfo propertyInfo)
        {
            Name = propertyInfo.Name;
            TypeName = propertyInfo.PropertyType.ToString();
        }

        
    }
}
