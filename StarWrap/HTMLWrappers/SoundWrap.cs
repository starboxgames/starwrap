using System;
using System.Collections.Generic;
using System.Text;
using System.Html;

using System.Runtime.CompilerServices;

namespace StarWrap.Wrappers
{
    class SoundWrap : ISoundWrap
    {
        Dictionary<string,AudioElement> sounds = new Dictionary<string,AudioElement>();

        public bool AllLoaded { get; set; }
        public bool LoadingFailed { get; set; }

        public SoundWrap()
        {
            AllLoaded = false;
            LoadingFailed = false;
            NumSoundsLoaded = -1;
            NumSounds = 0;
        }

        void OnLoad(Event a)
        {
            NumSoundsLoaded++;

            if (NumSoundsLoaded == NumSounds) AllLoaded = true;
        }

        void OnError(Event a)
        {
            LoadingFailed = true;
        }


        [InlineCode("this.$source.preload = {how}")]
        void SourcePreload(string how)
        {

        }


        void LoadSound(string name, string location)
        {
            AudioElement audio = (AudioElement)Document.CreateElement("audio");

            audio.SetAttribute("src", location);

            

            audio.OnLoad = OnLoad;
            audio.OnError = OnError;

            audio.Load();

            audio.Volume = 0.5;

            sounds.Add(name, audio);
        }

        public int NumSoundsLoaded { get; set; }
        public int NumSounds { get; set; }

        public void PlaySound(string name, bool loop = false)
        {
            AudioElement sound = sounds[name];
            if (loop) sound.Loop = true;

            sound.Pause();
            sound.Play();

            
        }

        Dictionary<string, string> soundList = new Dictionary<string, string>();

        public void AddSound(string name, string location)
        {
            soundList.Add(name, location);
        }

        public void LoadSounds()
        {
            NumSounds = -1;


            foreach(KeyValuePair<string, string> sndname in soundList)
            {
                LoadSound(sndname.Key, sndname.Value);
            }

            NumSounds = sounds.Count;

            AllLoaded = true;
        }
    }
}
