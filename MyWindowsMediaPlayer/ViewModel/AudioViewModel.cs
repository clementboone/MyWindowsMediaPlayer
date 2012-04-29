using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Player.Audio;

namespace MyWindowsMediaPlayer.ViewModel
{
    class AudioViewModel
    {
        private Audio _currentAudio;
      
        public ICommand PlayAudio { get; private set; }
        public ICommand NextAudio { get; private set; }
        public ICommand PrevAudio { get; private set; }
        public ICommand PauseAudio{ get; private set; }
        public ICommand StopAudio { get; private set; }
        


        public AudioViewModel()
        {
            this.PlayAudio = new RelayCommand(PerformPlayAudio);
            this.PrevAudio = new RelayCommand(PerformPrevAudio);
            this.NextAudio = new RelayCommand(PerformNextAudio);
            this.PauseAudio = new RelayCommand(PerformPauseAudio);
            this.StopAudio = new RelayCommand(PerformStopAudio);
            this._currentAudio = new Audio(@"ctotot");
        }

        private void PerformPlayAudio()
        {
            Console.WriteLine("TEST");
        }

        private void PerformStopAudio()
        {
            Console.WriteLine("STOP");

        }

        private void PerformNextAudio()
        {
            Console.WriteLine("NEXT");
        }

        private void PerformPrevAudio()
        {
            Console.WriteLine("PREV");
        }

        private void PerformPauseAudio()
        {
            Console.WriteLine("PAUSE");
        }
    }
}
