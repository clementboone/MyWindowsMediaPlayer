using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    class ImageViewModel : ViewModelBase
    {
        private Image _image;
        public string Name
        {
            get 
            {
                return System.IO.Path.GetFileName(this._image.Location);
            }
        }

        public ImageViewModel(string path)
        {
            this._image = new Image();
            this._image.Location = path;
        }
    }
}
