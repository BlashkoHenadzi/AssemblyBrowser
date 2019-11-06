using AssemblyBrowser.structure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.VM
{
    public class VMConverter
    {
        public ObservableCollection<TreeNode> treeNodes { get; }
        public  VMConverter(BrowseResult browseResult)
        {
            treeNodes = new ObservableCollection<TreeNode>();
            foreach(NamespaceNode namespaceNode in browseResult.Namespaces)
            {
                treeNodes.Add(new TreeNode(namespaceNode.Name));
                treeNodes.Last().Nodes =  TypesConverter(namespaceNode.TypeNodes);
            }
           
        }
        
        private ObservableCollection<TreeNode> TypesConverter(ObservableCollection<TypeNode> typeNodes)
        {
            ObservableCollection<TreeNode> treeNodes = new ObservableCollection<TreeNode>();
            foreach(TypeNode typeNode in typeNodes)
            {
                treeNodes.Add(new TreeNode(typeNode.Name));
                treeNodes.Last().Nodes.Add(MethodConverter(typeNode.methods));
                treeNodes.Last().Nodes.Add(FieldsConverter(typeNode.fields));
                treeNodes.Last().Nodes.Add(PropertyConverter(typeNode.propertus));
            }
            return treeNodes;         
            
        }

        private TreeNode PropertyConverter(ObservableCollection<PropertuNode> propertus)
        {
            TreeNode treeNode = new TreeNode("property");
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (PropertuNode propertuNode in propertus)
            {
                treeNodes.Add(new TreeNode(propertuNode.TypeName));
            }
            treeNode.Nodes = treeNodes;
            return  treeNode;
        }

        private TreeNode FieldsConverter(ObservableCollection<FieldNode> fields)
        {
            TreeNode treeNode = new TreeNode("fields");
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (FieldNode fieldNode in fields)
            {
                treeNodes.Add(new TreeNode(fieldNode.TypeName));
            }
            treeNode.Nodes = treeNodes;
            return treeNode;
        }

        private TreeNode MethodConverter(ObservableCollection<MethodNode> methods)
        {
            TreeNode treeNode = new TreeNode("methods");
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (MethodNode methodNode in methods)
            {
                treeNodes.Add(new TreeNode(methodNode.Signature));
            }
            treeNode.Nodes = treeNodes;
            return treeNode;
        }
    }
}
