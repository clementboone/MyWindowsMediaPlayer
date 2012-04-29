using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Player.Audio;

namespace MyWindowsMediaPlayer.ViewModel
{
    class AudioViewModel
    {
        private Audio _track;
        public string Name { get { return this._track.ToString(); } }

        public AudioViewModel(Audio track)
        {
            this._track = track;
        }
    }
}
