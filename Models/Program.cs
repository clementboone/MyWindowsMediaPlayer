using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Player.Audio;

namespace Player
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player.Audio.Audio audio = new Player.Audio.Audio();

            audio.AudioPlayer = new NAudioPlayer(ref audio);
            audio.AudioTagger = new ID3Tagger(ref audio);
            Console.WriteLine("Artiste = " + audio.AudioTagger.Artist);
            audio.AudioPlayer.Play();
            System.Threading.Thread.Sleep(5000);
            audio.AudioPlayer.Dispose();
        }
    }
}
