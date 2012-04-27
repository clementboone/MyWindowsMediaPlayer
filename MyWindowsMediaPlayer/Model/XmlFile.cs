using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MyWindowsMediaPlayer.Model
{
    public abstract class XmlFile
    {
        protected XDocument _xmlDocument;
        protected string _filePath;

        protected bool saveDocument()
        {
            try
            {
                this._xmlDocument.Save(this._filePath);
                this.reload();
            }
            catch (System.Exception exception)
            {
                Console.WriteLine("Model.saveDocument() fail. err : " + exception.Message);
                return false;
            }
            return true;
        }

        public bool loadFile(string path)
        {
            try
            {
                this._xmlDocument = XDocument.Load(path);
                this._filePath = path;
            }
            catch (System.Exception exception)
            {
                Console.WriteLine("Model.loadDocument() fail. err : " + exception.Message);
                return false;
            }
            return true;
        }
        public bool reload()
        {
            return this.loadFile(this._filePath);
        }
        protected bool addElementToNode(XElement newElement, XContainer container)
        {
            try
            {
                container.Add(newElement);
                this.saveDocument();
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(this.ToString() + "->addElementToNode Exception. Err : " + exception.Message);
                return false;
            }
            return true;
        }
        public bool remove()
        {
            this._xmlDocument.RemoveNodes();
            return true;
        }
    }
}
