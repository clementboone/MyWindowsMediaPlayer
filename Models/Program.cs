using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Models
{
    class Program
    {
        static void Main(string[] args)
        {
           Video    video = new Video(@"C:\Users\Public\Videos\Sample Videos\Wildlife.wmv");
           video.VideoPlayer = new BasicVideoPlayer(video);
           video.VideoPlayer.play();
        }
    }
}
