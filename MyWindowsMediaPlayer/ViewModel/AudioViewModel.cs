using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Windows.Input;
=======

>>>>>>> a10378bed8cefddc23bbc91dfd434d625bcea4a1
using Player.Audio;

namespace MyWindowsMediaPlayer.ViewModel
{
    class AudioViewModel
    {
<<<<<<< HEAD
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
=======
        private Audio _track;
        public string Name { get { return this._track.ToString(); } }

        public AudioViewModel(Audio track)
        {
            this._track = track;
>>>>>>> a10378bed8cefddc23bbc91dfd434d625bcea4a1
        }
    }
}
