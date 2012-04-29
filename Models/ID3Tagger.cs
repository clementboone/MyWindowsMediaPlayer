using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HundredMilesSoftware.UltraID3Lib;

namespace Player.Audio
{
    class ID3Tagger : IAudioTagger
    {
        UltraID3 UltraID3;

        public ID3Tagger(ref Audio media)
        {
            this.UltraID3 = new UltraID3();
            this.UltraID3.Read(media.Location);
        }

        public string Artist
        {
            get
            {
                return this.UltraID3.Artist;
            }
            set
            {
                this.UltraID3.Artist = value;
            }
        }

        public string Album
        {
            get
            {
                return this.UltraID3.Album;
            }
            set
            {
                this.UltraID3.Album = value;
                this.UltraID3.Write();
            }
        }

        public short Year
        {
            get
            {
                return (short)this.UltraID3.Year;
            }
            set
            {
                this.UltraID3.Year = value;
                this.UltraID3.Write();
            }
        }


        public string Title
        {
            get
            {
                return this.UltraID3.Title;
            }
            set
            {
                this.UltraID3.Title = value;
                this.UltraID3.Write();
            }
        }

        public string Genre
        {
            get
            {
                return this.UltraID3.Genre;
            }
            set
            {
                this.UltraID3.Genre = value;
                this.UltraID3.Write();
            }
        }
    }
}
