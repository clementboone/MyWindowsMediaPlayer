using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWindowsMediaPlayer.Model
{
    public class Category : Filter
    {
        public List<string> Extentions;
        public string Type { get; private set; }


        public Category(string name, string extentions, string type)
            : base(name, null)
        {
            string[] tempExtentionTab = extentions.Split(',');
            this.Extentions = new List<string>();
            foreach (string singleExtention in tempExtentionTab)
            {
                if (singleExtention != "")
                this.Extentions.Add(singleExtention);
            }
            this.Type = type;
        }
    }
}
