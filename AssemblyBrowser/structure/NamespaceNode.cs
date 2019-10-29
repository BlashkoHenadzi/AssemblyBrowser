using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.structure
{
    class NamespaceNode : INode
    {
        public string Name { get; set; }
        public List<TypeNode> TypeNodes { get; set; }

        public NamespaceNode(string name)
        {
            Name = name;
            TypeNodes = new List<TypeNode>();
        }
    }
}
