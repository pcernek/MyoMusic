using CSCore;
using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SynthApp
{
    class Note
    {
        private ISoundOut _soundOut;
        private IWaveSource _waveSource;
        private MMDevice _device;

        private Dictionary<string, string> drumNotes;

        public Note(string fileName, MMDevice device)
        {
            this.Open(fileName);
            this._device = device;
        }

        private void Open(string filename)
        {
            CleanupPlayback();

            _waveSource =
                CodecFactory.Instance.GetCodec(filename)
                    .ToSampleSource()
                    .ToMono()
                    .ToWaveSource();
            _soundOut = new WasapiOut() { Latency = 100, Device = this._device };
            _soundOut.Initialize(_waveSource);
        }

        public void Play()
        {
            if (_soundOut != null)
                _soundOut.Play();
        }

        private void CleanupPlayback()
        {
            if (_soundOut != null)
            {
                _soundOut.Dispose();
                _soundOut = null;
            }
            if (_waveSource != null)
            {
                _waveSource.Dispose();
                _waveSource = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            CleanupPlayback();
        }
    }
}
