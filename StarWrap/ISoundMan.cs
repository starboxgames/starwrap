using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap.Managers
{
    interface ISoundMan
    {
        bool AllLoaded { get; set; }
        bool LoadingFailed { get; set; }

        void PlaySound(string name, bool music = false);
        void LoadSounds();
    }
}
