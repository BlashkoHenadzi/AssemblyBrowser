using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace AssemblyBrowser.structure
{
    public class TypeNode : INode
    {
        public string Name { get; set; }
        public string Typeinfo { get; set; }
        public ObservableCollection<PropertuNode> propertus { get; set; }
        public ObservableCollection<FieldNode> fields { get; set; }
        public ObservableCollection<MethodNode> methods { get; set; }

        public TypeNode(Type type)
        {
            Name = ModifiersGenerator.GetAtributes(type) + type.Name;
            propertus = new ObservableCollection<PropertuNode>();
            fields = new ObservableCollection<FieldNode>();
            methods = new ObservableCollection<MethodNode>();
            GetFields(type);
            GetProperties(type);
            GetMethods(type);
            GetTypeSignature();
        }

        private void GetTypeSignature()
        {
            
            if (fields.Count>0)
                Typeinfo = "\tFields:\n\t\t";
            foreach (FieldNode field in fields)                          
                Typeinfo += field.TypeName + " " + field.Name + "\n\t\t";
            if (propertus.Count > 0)
                Typeinfo += "\n\tProperties\n\t\t";
            foreach (PropertuNode property in propertus) 
                Typeinfo += property.TypeName + " " + property.Name + "\n\t\t";
            if (methods.Count > 0)
                Typeinfo += "\n\tMethods\n\t\t";
            foreach (MethodNode method in methods)              
                Typeinfo += method.Signature + "\n\t\t";           

            this.Typeinfo = Typeinfo;
        }

        private void GetFields(Type type)
        {            
            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                fields.Add(new FieldNode(fieldInfo));
            }
        }
        private void GetProperties(Type type)
        {
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                propertus.Add(new PropertuNode(propertyInfo));
            }

        }
        private void GetMethods(Type type)
        {
            foreach(MethodInfo method in type.GetMethods())
            {
                methods.Add(new MethodNode(method));
            }
        }
    }
}
