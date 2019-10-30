using AssemblyBrowser.structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace AssemblyBrowser
{
    public class ViewModel : INotifyPropertyChanged
    {
        private BrowseResult _browseResult;
        private AssemblyLoader _loader;
        public event PropertyChangedEventHandler PropertyChanged;
    
        private RelayCommand _openCommand;

        public ViewModel()
        {
            _loader = new AssemblyLoader();
        }

        public BrowseResult Result
        {
            get { return _browseResult; }
            set
            {
                _browseResult = value;
                OnPropertyChanged();
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                    (_openCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                Result = _loader.Load(openFileDialog.FileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }));
            }
        }
    }
}

