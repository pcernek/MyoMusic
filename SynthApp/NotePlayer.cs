using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
using System.Collections.Generic;
using System.ComponentModel;

namespace SynthApp
{
    public class NotePlayer
    {
        private ISoundOut _soundOut;
        private IWaveSource _waveSource;

        private Dictionary<string, Note> drumNotes;

        public NotePlayer()
        {
            using (var mmdeviceEnumerator = new MMDeviceEnumerator())
            {
                using (
                    var mmdeviceCollection = mmdeviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
                {
                    MMDevice device = mmdeviceCollection[0];
                    this.drumNotes = new Dictionary<string, Note>()
                    {
                        { "C", new Note("notes/drum-1.wav", device) },
                        { "D", new Note("notes/drum-2.wav", device) },
                        { "E", new Note("notes/drum-3.wav", device) },
                        { "G", new Note("notes/drum-4.wav", device) },
                        { "A", new Note("notes/drum-5.wav", device) },
                    };
                }
            }

        }

        public void playDrumNote(string note)
        {
            this.drumNotes[note].Play();
        }
    }
}
