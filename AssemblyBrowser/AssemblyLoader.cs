using AssemblyBrowser.structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace AssemblyBrowser
{
    class AssemblyLoader
    {

        public AssemblyLoader()
        {            
        }
        public BrowseResult Load(string path)
        {
           
            Assembly assembly = Assembly.LoadFrom(path);
            return new BrowseResult(assembly);
            
                 
                 
        }
       
    }
}
