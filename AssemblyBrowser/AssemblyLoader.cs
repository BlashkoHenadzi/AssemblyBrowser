using AssemblyBrowser.structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace AssemblyBrowser
{
    public class AssemblyLoader
    {

        public AssemblyLoader()
        {            
        }
        public BrowseResult Load(string path)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(path);
                return new BrowseResult(assembly);
            }
            catch
            {
                return null;
            }
        }
       
    }
}
