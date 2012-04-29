using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Player.Audio
{
    public class MediaSoundPlayer : IAudioPlayer
    {
        private Player.Audio.Audio Audio;
        private  System.Media.SoundPlayer Player;

        public MediaSoundPlayer(ref Player.Audio.Audio audio)
        {
            this.Audio = audio;
            this.Player = new System.Media.SoundPlayer(audio.Location);
        }

        public void Play()
        {
            this.Player.Play();
        }

        public void Stop()
        {
            this.Player.Stop();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }


        public void SetVolume(float volume)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
