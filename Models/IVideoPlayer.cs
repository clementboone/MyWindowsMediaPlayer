using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    public interface IVideoPlayer
    {
       void play();
       void stop();
       void pause();

    }
}
