using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.structure
{
    public class MethodNode : INode
    {
        public MethodNode(MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            Signature = methodInfo.ToString();
        }

        public string Name { get; set; }
        public string Signature { get; set; }
    }
}
