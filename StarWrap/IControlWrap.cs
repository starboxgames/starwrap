using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap.Wrappers
{
    interface IControlWrap
    {
        void AddButton(string name, string key);
        void ReplaceButton(string name, string key);
        
        void ApplyControls();

        bool IsKeyPressed(string name);
    }
}
