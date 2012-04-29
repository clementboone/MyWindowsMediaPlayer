using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player.Video
{
    class Video : Media
    {
        public IVideoPlayer VideoPlayer { get; set; }
        
        public Video(string location)
            : base(location)
        {

        }
    }
}
