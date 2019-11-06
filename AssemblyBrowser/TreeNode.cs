using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public class TreeNode
    {
        public string Name { get; }
        public IList<TreeNode> Nodes { get; set; }

        public TreeNode(string name)
        {
            Name = name;
            Nodes = new List<TreeNode>();
        }
    }
}
