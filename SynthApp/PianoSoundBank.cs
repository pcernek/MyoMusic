using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthApp
{
    class PianoSoundBank : ISoundBank
    {
        public string GetSound1()
        {
            return "piano-C.wav";
        }

        public string GetSound2()
        {
            return "piano-D.wav";
        }

        public string GetSound3()
        {
            return "piano-E.wav";
        }

        public string GetSound4()
        {
            return "piano-G.wav";
        }

        public string GetSound5()
        {
            return "piano-A.wav";
        }
    }
}
