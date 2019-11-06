using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.structure
{
    public class BrowseResult
    {
        public ObservableCollection<NamespaceNode> Namespaces { get; set; }

        public BrowseResult(Assembly assembly)
        {
            Namespaces = new ObservableCollection<NamespaceNode>() ;
            GetNamespaces(assembly);
            GetTypes(assembly);
        }
        public void GetNamespaces(Assembly assembly)
        {
            IEnumerable<string> namespaces = assembly.GetTypes().Select(t => t.Namespace).Distinct();
            foreach (string namespc in namespaces)
                Namespaces.Add(new NamespaceNode(namespc));
        }
        public void GetTypes(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                Namespaces.Where(x => x.Name == type.Namespace).Single().TypeNodes.Add(new TypeNode(type));
            }
        }
    }
}
