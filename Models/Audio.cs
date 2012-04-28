using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    class Audio :  Media
    {
        public IAudioPlayer AudioPlayer { get; set; }
        public IAudioTagger AudioTagger { get; set; }

        public Audio(string location) : base(location)
        {

        }
    }
}
