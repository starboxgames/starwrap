using System;
using System.Collections.Generic;
using System.Text;

namespace StarWrap
{
    class SoundList
    {
        public Dictionary<string, string> Sounds = new Dictionary<string, string>();

        public SoundList()
        {
            Sounds.Add("jump", "snd/jump.wav");
            Sounds.Add("pickup", "snd/pickup.wav");
            Sounds.Add("throw", "snd/throw.wav");
            Sounds.Add("breakbox", "snd/breakbox.wav");
            Sounds.Add("drop", "snd/drop.wav");
        }
    }
}
