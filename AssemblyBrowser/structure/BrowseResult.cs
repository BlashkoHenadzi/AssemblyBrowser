using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.structure
{
    class BrowseResult
    {
        private List<NamespaceNode> Namespaces { get; set; }

        public BrowseResult(List<NamespaceNode> namespaces)
        {
            Namespaces = namespaces;
        }
        
    }
}
