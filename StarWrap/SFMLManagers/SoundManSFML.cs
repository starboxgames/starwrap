using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;

namespace StarWrap.Managers
{
    class SoundMan : ISoundMan
    {
        public bool AllLoaded { get; set; }
        public bool LoadingFailed { get; set; }   

        public SoundMan()
        {
            for (int i = 0; i < sound.Count(); i++) sound[i] = new Sound();

            AllLoaded = false;
            LoadingFailed = false;
        }

        static Dictionary<string, SoundBuffer> sounds = new Dictionary<string, SoundBuffer>();
        static Sound[] sound = new Sound[10];

        public void PlaySound(string name, bool loop)
        {
            SoundBuffer s;
            sounds.TryGetValue(name, out s);

            for (int i = 0; i < sound.Count(); i++)
            {
                if (sound[i].Status == SoundStatus.Stopped)
                {
                    sound[i].SoundBuffer = s;
                    sound[i].Play();
                    break;
                }
            }
        }

        public void LoadSounds()
        {
            SoundList soundList = new SoundList();

            AllLoaded = true;
            LoadingFailed = false;

            foreach(KeyValuePair<string, string> sndname in soundList.Sounds)
            {
                try
                {
                    sounds.Add(sndname.Key, new SoundBuffer(sndname.Value));
                }
                catch (SFML.LoadingFailedException)
                {
                    AllLoaded = false;
                    LoadingFailed = true;
                    break;
                }
            }
        }
    }
}
