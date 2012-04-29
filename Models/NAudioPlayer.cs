using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;
using BigMansStuff.NAudio.FLAC;
using BigMansStuff.NAudio.Ogg;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;

namespace Player.Audio
{

   
    public class NAudioPlayer : IAudioPlayer
    {
        private Audio media;
        private IWavePlayer waveOutDevice;
        private WaveStream mainOutputStream;
        private WaveChannel32 volumeStream;
      
        public NAudioPlayer(ref Audio media)
        {
            this.waveOutDevice = new WaveOut();
            this.media = media;
            this.CreateInputStream();
         }

        private void CreateInputStream()
        {
            string extension = Path.GetExtension(this.media.Location);
            ICollection keyColl = LocalWaveStreamFactory.openWith.Keys;
            if (LocalWaveStreamFactory.openWith.ContainsKey(extension))
                this.mainOutputStream = LocalWaveStreamFactory.openWith[extension](media.Location);
            else
                throw new InvalidOperationException("Unsupported extension");
            this.volumeStream = new WaveChannel32(this.mainOutputStream);
            this.waveOutDevice.Init(this.mainOutputStream);
        }

        public void Play()
        {
            this.waveOutDevice.Play();
        }

        public void Stop()
        {
            this.waveOutDevice.Stop();
        }


        public void SetVolume(float volume)
        {
            if (volume > 1.0)
                return;
            Console.WriteLine("Volume :" + volume);
            this.volumeStream.Volume = volume;
        }

        public void Pause()
        {
            this.waveOutDevice.Pause();
        }


        public void Dispose()
        {
            if (this.waveOutDevice != null)
                waveOutDevice.Stop();
            if (this.mainOutputStream != null)
            {
                this.volumeStream.Close();
                this.volumeStream = null;
                this.mainOutputStream.Close();
                this.mainOutputStream = null;
            }
            if (this.waveOutDevice != null)
            {
                this.waveOutDevice.Dispose();
                this.waveOutDevice = null;
            }

        }
    }
}
