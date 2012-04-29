using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player.Video
{
    public class Video : Media
    {
        public IVideoPlayer VideoPlayer { get; set; }

        public Video()
        { }
    }
}
