using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player.Audio
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
