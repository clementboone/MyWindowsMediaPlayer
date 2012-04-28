using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWindowsMediaPlayer.Model
{
    class File
    {
        public string Name { get; protected set; }

        public File(string name)
        {
            this.Name = name;
        }
    }
}
