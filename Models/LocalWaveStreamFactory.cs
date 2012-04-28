using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;
using BigMansStuff.NAudio.FLAC;
using BigMansStuff.NAudio.Ogg;

namespace Models
{
    static class LocalWaveStreamFactory
    {
        public static Dictionary<string, Func<string, WaveStream>> openWith { get; private set; }
        static LocalWaveStreamFactory()
        {
            openWith = new Dictionary<string, Func<string, WaveStream>>();
            openWith[".mp3"] = LocalWaveStreamFactory.createMp3Reader;
            openWith[".flac"] = LocalWaveStreamFactory.createFlacReader;
            openWith[".ogg"] = LocalWaveStreamFactory.createOggVorbisReader;
            openWith[".wav"] = LocalWaveStreamFactory.createWavReader;
            openWith[".aiff"] = LocalWaveStreamFactory.createAiffReader;
        }

        static public WaveStream createMp3Reader(string location)
        {
            return new Mp3FileReader(location);
        }

        static public WaveStream createFlacReader(string location)
        {
            return new FLACFileReader(location);
        }

        static public WaveStream createOggVorbisReader(string location)
        {
            return new OggVorbisFileReader(location);
        }

        static public WaveStream createWavReader(string location)
        {
            return new WaveFileReader(location);
        }

        static public WaveStream createAiffReader(string location)
        {
            return new AiffFileReader(location);
        }
    }
}
