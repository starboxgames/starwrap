using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;

namespace StarWrap.Wrappers
{
    class SoundWrap : ISoundWrap
    {
        public bool AllLoaded { get; set; }
        public bool LoadingFailed { get; set; }   

        public SoundWrap()
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
                    sound[i].Volume = 50;
                    break;
                }
            }
        }

        Dictionary<string, string> soundList = new Dictionary<string, string>();

        public void AddSound(string name, string location)
        {
            soundList.Add(name, location);
        }

        public void LoadSounds()
        {
            AllLoaded = true;
            LoadingFailed = false;

            foreach(KeyValuePair<string, string> sndname in soundList)
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
