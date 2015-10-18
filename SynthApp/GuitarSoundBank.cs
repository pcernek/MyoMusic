using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthApp
{
    class GuitarSoundBank : ISoundBank
    {
        public string GetSound1()
        {
            return "guitar-C.wav";
        }

        public string GetSound2()
        {
            return "guitar-D.wav";
        }

        public string GetSound3()
        {
            return "guitar-E.wav";
        }

        public string GetSound4()
        {
            return "guitar-G.wav";
        }

        public string GetSound5()
        {
            return "guitar-A.wav";
        }
    }
}
