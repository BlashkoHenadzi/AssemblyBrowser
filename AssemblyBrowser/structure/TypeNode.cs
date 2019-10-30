using System;
using System.Collections.Generic;
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
        public List<PropertuNode> propertus;
        public List<FieldNode> fields;
        public List<MethodNode> methods;

        public TypeNode(Type type)
        {
            Name = ModifiersGenerator.GetAtributes(type) + type.Name;
            propertus = new List<PropertuNode>();
            fields = new List<FieldNode>();
            methods = new List<MethodNode>();
            GetFields(type);
            GetProperties(type);
            GetMethods(type);
            GetTypeSignature();
        }

        private void GetTypeSignature()
        {
            

            foreach (FieldNode field in fields)
            {
                Typeinfo = "\tFields:\n\t\t";
                Typeinfo += field.TypeName + " " + field.Name + "\n\t\t";
            }



            foreach (PropertuNode property in propertus)
            {
                Typeinfo += "\n\tProperties\n\t\t";
                Typeinfo += property.TypeName + " " + property.Name + "\n\t\t";
            }



            foreach (MethodNode method in methods)
            {
                Typeinfo += "\n\tMethods\n\t\t";
                Typeinfo += method.Signature + "\n\t\t";
            }

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
