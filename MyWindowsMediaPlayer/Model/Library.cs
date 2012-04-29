using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace MyWindowsMediaPlayer.Model
{
    public class Library : XmlFile
    {
        private List<Filter> _categories;
        public List<Filter> Categories
        {
            get
            {
                return this._categories;
            }
            set
            {
                this._categories = value;
            }
        }
        private Filter newFilter(XElement xmlNode, Filter parent)
        {
            Filter newFilter;
            string filterName = xmlNode.Attribute("name").Value;
            if (parent == null)
            {
                string extention = (xmlNode.Attribute("extentions") != null ? xmlNode.Attribute("extentions").Value : "");
                string type = (xmlNode.Attribute("type") != null ? xmlNode.Attribute("type").Value : "");
                // string path = Path.ChangeExtension(this._filePath, "") + "_" + filterName + ".xml";
                newFilter = new Category(filterName, extention, type);
            }
            else
            {
                newFilter=  new Filter(filterName, parent);
            }
            return newFilter;
        }
        private Filter createNewFilter(XElement line, Filter parent)
        {
            if (parent == null)
                return new Category(
                    line.Attribute("name").Value,
                    line.Attribute("extentions") != null ? line.Attribute("extentions").Value : "",
                    line.Attribute("type") != null ? line.Attribute("type").Value : ""
                    );
            else
                return new Filter(line.Attribute("name").Value, parent);
        }
        private List<Filter> loadFilters(IEnumerable<XElement> filters, Filter parent)
        {
            if (filters != null)
            {
                List<Filter> tempList = new List<Filter>();
                Filter tempFilter = null;
                foreach (XElement element in filters)
                {
                    if (element.Attribute("name") != null)
                    {
                        tempFilter = this.createNewFilter(element, parent);
                        if (element.Elements() != null)
                            tempFilter.Filters = this.loadFilters(element.Elements(), tempFilter);
                        tempList.Add(tempFilter);
                    }
                }
                return tempList;
            }
            return new List<Filter>();
        }
        private List<Filter> loadCategories()
        {
            IEnumerable<XElement> categories = null;
            try
            {
                categories = from element in this._xmlDocument.Elements().Elements()
                                                   select element;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Library.loadCategories() fail. err : " + exception.Message);
            }
            return this.loadFilters(categories, null);
        }
        public Library(string path = "")
        {
            if (path != "")
            {
                this._filePath = path;
                Properties.Settings.Default.LibPath = path;
            }
            else
                this._filePath = Properties.Settings.Default.LibPath;
            this.loadFile(this._filePath);
            this.Categories = this.loadCategories();
        }

        public bool addCategory(string name)
        {
            XElement newCategory = new XElement("category");
            newCategory.SetAttributeValue("name", name);
            return this.addElementToNode(newCategory, this._xmlDocument.Elements().First());
        }
        public bool addFilter(string name, Category parent)
        {
            XElement newFilter = new XElement("filter");
            newFilter.SetAttributeValue("name", name);
            newFilter.SetAttributeValue("parent", parent.Name);
            IEnumerable<XContainer> xParent = from element in this._xmlDocument.Elements().Elements()
                                            where element.Attribute("name").Value == parent.Name
                                                select element;
            return this.addElementToNode(newFilter, xParent.First());
        }
    }
}
