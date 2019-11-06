using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.structure
{
    public class NamespaceNode : INode
    {
        public string Name { get; set; }
        public ObservableCollection<TypeNode> TypeNodes { get; set; }

        public NamespaceNode(string name)
        {
            Name = name;
            TypeNodes = new ObservableCollection<TypeNode>();
        }
    }
}
