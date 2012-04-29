using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player.Audio
{
    interface IAudioTagger
    {
        string Artist{ get; set; }
        string Album { get; set; }
        string Title { get; set; }
        string Genre { get; set; }
        short  Year { get; set; }
    }
}
