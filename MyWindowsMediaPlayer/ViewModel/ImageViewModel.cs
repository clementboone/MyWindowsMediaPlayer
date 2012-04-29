using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class ImageViewModel : MediaViewModel
    {
        private Image _image;
        public string ImagePath {
            get { return this._image.Location;  }
        }
        public string Name
        {
            get 
            {
                return System.IO.Path.GetFileName(this._image.Location);
            }
        }
        private ICommand _doubleClick;
        public ICommand DoubleClickCommand
        {
            get
            {
                if (this._doubleClick == null)
                    this._doubleClick = new RelayCommand(() => this.DoubleClick());

                return this._doubleClick;
            }
        }

        private void DoubleClick()
        {
            Console.WriteLine("Double Click");
        }

        public ImageViewModel(string path)
        {
            this._image = new Image();
            this._image.Location = path;
        }

    }
}
