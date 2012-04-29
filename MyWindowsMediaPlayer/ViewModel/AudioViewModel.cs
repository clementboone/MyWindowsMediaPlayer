using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Player.Audio;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class AudioViewModel
    {
        private Audio _currentAudio;

        public ICommand PlayAudio { get; private set; }
        public ICommand NextAudio { get; private set; }
        public ICommand PrevAudio { get; private set; }
        public ICommand PauseAudio{ get; private set; }
        public ICommand StopAudio { get; private set; }

        public string Artist { get { return this._currentAudio.AudioTagger.Artist; } }
        public string Album { get { return this._currentAudio.AudioTagger.Album; } }
        public string Title { get { return this._currentAudio.AudioTagger.Title; } }
        public string Genre { get { return this._currentAudio.AudioTagger.Genre; } } 
        public short Year { get { return this._currentAudio.AudioTagger.Year; } }

     
        public AudioViewModel(string path)
        {
            this.CommandSetter();
            this._currentAudio = new Audio();
            this._currentAudio.Location = path;
            this._currentAudio.AudioPlayer = new NAudioPlayer(ref this._currentAudio);
            this._currentAudio.AudioTagger = new ID3Tagger(ref this._currentAudio);
        }

        public AudioViewModel(Audio audio)
        {
            this.CommandSetter();
            this._currentAudio = audio;
            this._currentAudio.AudioPlayer = new NAudioPlayer(ref this._currentAudio);
            this._currentAudio.AudioTagger = new ID3Tagger(ref this._currentAudio);
        }

        private void CommandSetter()
        {
            this.PlayAudio = new RelayCommand(PerformPlayAudio);
            this.PrevAudio = new RelayCommand(PerformPrevAudio);
            this.NextAudio = new RelayCommand(PerformNextAudio);
            this.PauseAudio = new RelayCommand(PerformPauseAudio);
            this.StopAudio = new RelayCommand(PerformStopAudio);
        }

        private void PerformPlayAudio()
        {
            this._currentAudio.AudioPlayer.Play();
        }

        private void PerformStopAudio()
        {
            this._currentAudio.AudioPlayer.Stop();
        }

        private void PerformNextAudio()
        {
            this._currentAudio.AudioPlayer.Dispose();
        }

        private void PerformPrevAudio()
        {
            this._currentAudio.AudioPlayer.Dispose();
        }

        private void PerformPauseAudio()
        {
            this._currentAudio.AudioPlayer.Pause();
        }
    }
}
