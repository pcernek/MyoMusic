using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthApp
{
    class DrumKitSoundBank : ISoundBank
    {
        public string GetSound1()
        {
            return "drum-1.wav";
        }

        public string GetSound2()
        {
            return "drum-2.wav";
        }

        public string GetSound3()
        {
            return "drum-3.wav";
        }

        public string GetSound4()
        {
            return "drum-4.wav";
        }

        public string GetSound5()
        {
            return "drum-5.wav";
        }
    }
}
