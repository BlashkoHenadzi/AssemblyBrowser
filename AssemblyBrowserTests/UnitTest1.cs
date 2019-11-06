using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowser;
using AssemblyBrowser.structure;
using System.Linq;

namespace AssemblyBrowserTests
{
    [TestClass]
    public class UnitTest1
    {
        BrowseResult browseResult;
        [TestInitialize]
        public void Initializie()
        {
            AssemblyLoader _assemblyLoader = new AssemblyLoader();
            browseResult = _assemblyLoader.Load(".\\AssemblyBrowser.dll");
        }
        [TestMethod]
        public void DllLoad_DllLoaded()
        {
            Assert.IsNotNull(browseResult);

        }
        [TestMethod]
        public void  NamespaceParse_NamespaceCountNotNull()
        {
            Assert.IsNotNull(browseResult.Namespaces.FirstOrDefault());
        }
        [TestMethod]
        public void TypeParse_TypeCountNotNull()
        {
            Assert.IsNotNull(browseResult.Namespaces[0].TypeNodes.FirstOrDefault());
        }
        [TestMethod]
        public void FieldParse_FiledCountNotNull()
        {
            Assert.IsNotNull(browseResult.Namespaces.Select(x => x.TypeNodes.Where(y => y.fields.Count > 0)));
        }
        [TestMethod]
        public void PropertyParse_PropertCountNotNull()
        {
            Assert.IsNotNull(browseResult.Namespaces.Select(x => x.TypeNodes.Where(y => y.propertus.Count > 0)));
        }
        [TestMethod]
        public void MethodParse_MethodCountNotNull()
        {
            Assert.IsNotNull(browseResult.Namespaces.Select(x => x.TypeNodes.Where(y => y.methods.Count > 0)));
        }
    }
}
