﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace MyWindowsMediaPlayer.Model
{
    class MediaList : XmlFile
    {
        private Filter _filter;
        private Category _category;
        private List<File> _mediasList;
        public List<File> MediasList { get { return this._mediasList; } set { this._mediasList = value; } }

        private void loadMedias(string filter)
        {
            IEnumerable<XElement> medias = from element in this._xmlDocument.Elements().Elements()
                                               select element;
            if (medias == null)
                return;
            File newFile = null;
            foreach (XElement line in medias)
            {
                if (line.Attribute("path") != null)
                {
                    newFile = new File(line.Attribute("path").Value);
                    this._mediasList.Add(newFile);
                }
            }
        }

        public MediaList(string path, Filter filter)
        {
            this._filePath = path;
            this._filter = filter;
            this._mediasList = new List<File>();
            this._category = filter.getCategory();
            foreach (string ext in this._category.Extentions)
                Console.WriteLine("Extention : " + ext);
            this.loadFile(this._filePath);
            this.loadMedias(filter.Name);
        }
        private string[] fileList(string path)
        {
            string[] filePaths = {};
            foreach (string extention in this._category.Extentions)
            {
                Console.WriteLine("Extention : " + extention);
                filePaths = filePaths.Union(Directory.GetFiles(path, "*." + extention, SearchOption.AllDirectories)).ToArray<string>();
            }
            return filePaths;
        }
        private bool addMedia(File newMedia)
        {
            XElement newNode = new XElement("file");
            newNode.SetAttributeValue("path", newMedia.Name);
            return this.addElementToNode(newNode, this._xmlDocument.Elements().First());
        }
        public int loadFolder(string path)
        {
            int nbNewMedia = 0;
            foreach (string newFile in this.fileList(path))
            {
                if (!this._mediasList.Exists(file => file.Name == newFile))
                {
                    this._mediasList.Add(new File(newFile));
                    this.addMedia(this._mediasList.Last());
                    nbNewMedia++;
                }
            }
            if (nbNewMedia > 0)
                this.saveDocument();
            Console.WriteLine("Loaded : " + nbNewMedia + " Total : " + this._mediasList.Count);
            return nbNewMedia;
        }
    }
}
