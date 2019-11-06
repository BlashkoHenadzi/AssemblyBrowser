using AssemblyBrowser.structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AssemblyBrowser.VM;
using System.Windows.Input;

namespace AssemblyBrowser
{
    public class ViewModel : INotifyPropertyChanged
    {        
           
            public event PropertyChangedEventHandler PropertyChanged;

            public ICommand Browse
            {
                get
                {
                    return new RelayCommand((obj) =>
                    {
                        System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                        if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string FilePath = dlg.FileName;
                            AssemblyLoader assemblyLoader = new AssemblyLoader();
                            BrowseResult browseResult = assemblyLoader.Load(FilePath);
                            if (browseResult != null)
                            {                                
                                VMConverter converter = new VMConverter(browseResult);
                                Nodes = converter.treeNodes;
                            }
                        }
                    }, (obj) => true);
                }
            }

            private ObservableCollection<TreeNode> _nodes;

            public ObservableCollection<TreeNode> Nodes
            {
                get
                {
                    return _nodes;
                }
                set
                {
                    _nodes = value;
                    OnAssemblyBrowsed();
                }
            }

            public void OnAssemblyBrowsed([CallerMemberName]string path = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(path));
            }

         

        }
    }

