using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player.Audio
{
    public class Audio : Media
    {
        public IAudioPlayer AudioPlayer { get; set; }
        public IAudioTagger AudioTagger { get; set; }

        public Audio()
        { }
    }
}
