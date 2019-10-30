using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace AssemblyBrowser.structure
{
    public class FieldNode : INode
    {
        public string Name { get; set; }
        public string TypeName { get; set; }

        public FieldNode(FieldInfo fieldInfo)
        {
            Name = fieldInfo.Name;
            TypeName = fieldInfo.FieldType.ToString();
        }

       
    }
}
