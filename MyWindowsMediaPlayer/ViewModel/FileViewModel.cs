using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Input;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    class FileViewModel
    {
        private File _file;
        private ICommand _infoCommand;


        public string Name
        {
            get
            {
                return this._file.Name;
            }
        }
        public FileViewModel()
        {
        }
        public ICommand DoubleClickCommand
        {
            get
            {
                if (this._infoCommand == null)
                    this._infoCommand = new RelayCommand(() => this.loadFile());

                return this._infoCommand;
            }
        }

        public void loadFile()
        {
            Console.WriteLine("Super " + this.Name);
        }
    }
}
