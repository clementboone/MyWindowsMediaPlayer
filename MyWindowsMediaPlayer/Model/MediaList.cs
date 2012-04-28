using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace MyWindowsMediaPlayer.Model
{
    class MediaList : XmlFile
    {
        private List<File> _medias;
        public List<File> Medias { get { return this._medias; } set { this._medias = value; } }

        private List<File> loadMedia()
        {
            IEnumerable<XElement> categories = from element in this._xmlDocument.Elements()
                                               select element;
            foreach (XElement line in categories)
            {
                if (line.Attribute("name") != null)
                {
                    tempFilter = new File(line.Attribute("name").Value, parent);
                    if (line.Elements() != null)
                        tempFilter.Filters = this.loadFilters(line.Elements(), tempFilter);
                    tempList.Add(tempFilter);
                }
            }
            return this.loadFilters(categories.Elements(), null);
        }

        public MediaList(string path = "")
        {
            if (path != "")
            {
                this._filePath = path;
                Properties.Settings.Default.LibPath = path;
            }
            else
                this._filePath = Properties.Settings.Default.LibPath;
            this.loadFile(this._filePath);
            this.Medias = this.loadMedias();
        }
    }
}
