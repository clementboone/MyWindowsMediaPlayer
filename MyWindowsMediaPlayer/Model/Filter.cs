using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace MyWindowsMediaPlayer.Model
{
    public class Filter : XmlObject
    {
        public Filter Parent { get; protected set; }
        public string Name { get; protected set; }
        public List<Filter> Filters
        {
            get;
            set;
        }


        public Filter(string name, Filter parent)
        {
            this.Name = name;
            this.Parent = parent;
            this.Filters = null;
        }
        protected Category getCategory()
        {
            if (this.Parent != null)
                return this.Parent.getCategory();
            else
                return (Category)this;
        }
    }
}
