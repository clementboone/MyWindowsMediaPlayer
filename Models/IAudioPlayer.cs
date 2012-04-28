using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    interface IAudioPlayer : IDisposable
    {
        void Play();
        void Stop();
        void SetVolume(float volume);
        void Pause();
    }
}
