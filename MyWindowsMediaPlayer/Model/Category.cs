using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWindowsMediaPlayer.Model
{
    public class Category : Filter
    {
        public List<string> Extentions { get; protected set; }

        public Category(string name) : base(name, null)
        {
            this.Extentions = new List<string>();
        }
    }
}
