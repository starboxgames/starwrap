using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap.Wrappers
{
    interface ISoundWrap
    {
        bool AllLoaded { get; set; }
        bool LoadingFailed { get; set; }

        void AddSound(string name, string location);

        void PlaySound(string name, bool music = false);
        void LoadSounds();
    }
}
