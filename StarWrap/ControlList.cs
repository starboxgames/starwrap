using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap
{
    class ControlList
    {
        public Dictionary<string, string> Controls = new Dictionary<string, string>();

        public ControlList()
        {
            Controls.Add("left", "key_Left");
            Controls.Add("right", "key_Right");
            Controls.Add("jump", "key_Z");
            Controls.Add("pickup", "key_X");
            Controls.Add("throw", "key_C");
            Controls.Add("quit", "key_Escape");
        }

        void LoadControls()
        {

        }
    }
}
