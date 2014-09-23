using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;

namespace StarWrap.Managers
{
    class ControlMan : IControlMan
    {
        Dictionary<string, Keyboard.Key> controls = new Dictionary<string,Keyboard.Key>();

        ControlList controlList = new ControlList();

        readonly Dictionary<string, Keyboard.Key> SFMLKeys = new Dictionary<string, Keyboard.Key>()
        {
            { "key_A", Keyboard.Key.A }, 
            { "key_B", Keyboard.Key.B }, 
            { "key_C", Keyboard.Key.C }, 
            { "key_D", Keyboard.Key.D }, 
            { "key_E", Keyboard.Key.E },  
            { "key_F", Keyboard.Key.F },  
            { "key_G", Keyboard.Key.G },  
            { "key_H", Keyboard.Key.H },  
            { "key_I", Keyboard.Key.I },  
            { "key_J", Keyboard.Key.J },  
            { "key_K", Keyboard.Key.K },  
            { "key_L", Keyboard.Key.L },  
            { "key_M", Keyboard.Key.M },  
            { "key_N", Keyboard.Key.N },  
            { "key_O", Keyboard.Key.O },  
            { "key_P", Keyboard.Key.P },  
            { "key_Q", Keyboard.Key.Q },  
            { "key_R", Keyboard.Key.R },  
            { "key_S", Keyboard.Key.S },  
            { "key_T", Keyboard.Key.T },  
            { "key_U", Keyboard.Key.U },  
            { "key_V", Keyboard.Key.V },  
            { "key_W", Keyboard.Key.W },  
            { "key_X", Keyboard.Key.X },  
            { "key_Y", Keyboard.Key.Y },  
            { "key_Z", Keyboard.Key.Z },  
            { "key_Num0", Keyboard.Key.Num0 },  
            { "key_Num1", Keyboard.Key.Num1 },  
            { "key_Num2", Keyboard.Key.Num2 },  
            { "key_Num3", Keyboard.Key.Num3 },  
            { "key_Num4", Keyboard.Key.Num4 },  
            { "key_Num5", Keyboard.Key.Num5 },  
            { "key_Num6", Keyboard.Key.Num6 },  
            { "key_Num7", Keyboard.Key.Num7 },  
            { "key_Num8", Keyboard.Key.Num8 },  
            { "key_Num9", Keyboard.Key.Num9 },  
            { "key_LControl", Keyboard.Key.LControl },  
            { "key_LShift", Keyboard.Key.LShift },  
            { "key_LAlt", Keyboard.Key.LAlt },  
            { "key_RControl", Keyboard.Key.RControl },  
            { "key_RShift", Keyboard.Key.RShift },  
            { "key_RAlt", Keyboard.Key.RAlt },  
            { "key_Escape", Keyboard.Key.Escape },  
            { "key_LBracket", Keyboard.Key.LBracket },  
            { "key_RBracket", Keyboard.Key.RBracket },  
            { "key_SemiColon", Keyboard.Key.SemiColon },
            { "key_Comma", Keyboard.Key.Comma },
            { "key_Period", Keyboard.Key.Period },
            { "key_Quote", Keyboard.Key.Quote },
            { "key_Slash", Keyboard.Key.Slash },
            { "key_BackSlash", Keyboard.Key.BackSlash },
            { "key_Tilde", Keyboard.Key.Tilde },
            { "key_Equal", Keyboard.Key.Equal },
            { "key_Dash", Keyboard.Key.Dash },
            { "key_Space", Keyboard.Key.Space },
            { "key_Return", Keyboard.Key.Return },
            { "key_Backspace", Keyboard.Key.Back },
            { "key_Tab", Keyboard.Key.Tab },
            { "key_PageUp", Keyboard.Key.PageUp },
            { "key_PageDown", Keyboard.Key.PageDown },
            { "key_End", Keyboard.Key.End },
            { "key_Home", Keyboard.Key.Home },
            { "key_Insert", Keyboard.Key.Insert },
            { "key_Delete", Keyboard.Key.Delete },
            { "key_Add", Keyboard.Key.Add },
            { "key_Subtract", Keyboard.Key.Subtract },
            { "key_Multiply", Keyboard.Key.Multiply },
            { "key_Divide", Keyboard.Key.Divide },
            { "key_Left", Keyboard.Key.Left },
            { "key_Right", Keyboard.Key.Right },
            { "key_Up", Keyboard.Key.Up },
            { "key_Down", Keyboard.Key.Down },
            { "key_Numpad0", Keyboard.Key.Numpad0 },
            { "key_Numpad1", Keyboard.Key.Numpad1 },
            { "key_Numpad2", Keyboard.Key.Numpad2 },
            { "key_Numpad3", Keyboard.Key.Numpad3 },
            { "key_Numpad4", Keyboard.Key.Numpad4 },
            { "key_Numpad5", Keyboard.Key.Numpad5 },
            { "key_Numpad6", Keyboard.Key.Numpad6 },
            { "key_Numpad7", Keyboard.Key.Numpad7 },
            { "key_Numpad8", Keyboard.Key.Numpad8 },
            { "key_Numpad9", Keyboard.Key.Numpad9 },
            { "key_F1", Keyboard.Key.F1 },
            { "key_F2", Keyboard.Key.F2 },
            { "key_F3", Keyboard.Key.F3 },
            { "key_F4", Keyboard.Key.F4 },
            { "key_F5", Keyboard.Key.F5 },
            { "key_F6", Keyboard.Key.F6 },
            { "key_F7", Keyboard.Key.F7 },
            { "key_F8", Keyboard.Key.F8 },
            { "key_F9", Keyboard.Key.F9 },
            { "key_F10", Keyboard.Key.F10 },
            { "key_F11", Keyboard.Key.F11 },
            { "key_F12", Keyboard.Key.F12 }
        };

        public ControlMan()
        {
            foreach(KeyValuePair<string, string> cntr in controlList.Controls)
            {
                controls.Add(cntr.Key, SFMLKeys[cntr.Value]);
            }
        }

        public bool IsKeyPressed(string name)
        {
            if (Keyboard.IsKeyPressed(controls[name])) return true;

            return false;
        }
    }
}
