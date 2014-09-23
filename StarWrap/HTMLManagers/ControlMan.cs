using System;
using System.Collections.Generic;
using System.Text;
using System.Html;


namespace StarWrap.Managers
{
    class ControlMan : IControlMan
    {
        bool[] keyPressed = new bool[255];

        ControlList controlList = new ControlList();

        Dictionary<string, int> controls = new Dictionary<string, int>();

        Dictionary<string, int> javaScriptKeys = new Dictionary<string, int>();


        public bool IsKeyPressed(string name)
        {
            return keyPressed[controls[name]];
        }

        void OnKeyDown(Event a)
        {
            KeyboardEvent k = (KeyboardEvent)a;

            keyPressed[k.KeyCode] = true;

        }

        void OnKeyUp(Event a)
        {
            KeyboardEvent k = (KeyboardEvent)a;

            keyPressed[k.KeyCode] = false;
        }


        public ControlMan()
        {
            Document.OnKeydown += OnKeyDown;
            Document.OnKeyup += OnKeyUp;

            javaScriptKeys.Add("key_A", 65); 
            javaScriptKeys.Add("key_B", 66); 
            javaScriptKeys.Add("key_C", 67); 
            javaScriptKeys.Add("key_D", 68); 
            javaScriptKeys.Add("key_E", 69);  
            javaScriptKeys.Add("key_F", 70);  
            javaScriptKeys.Add("key_G", 71);  
            javaScriptKeys.Add("key_H", 72);  
            javaScriptKeys.Add("key_I", 73);  
            javaScriptKeys.Add("key_J", 74);  
            javaScriptKeys.Add("key_K", 75);  
            javaScriptKeys.Add("key_L", 76);  
            javaScriptKeys.Add("key_M", 77);  
            javaScriptKeys.Add("key_N", 78);  
            javaScriptKeys.Add("key_O", 79);  
            javaScriptKeys.Add("key_P", 80);  
            javaScriptKeys.Add("key_Q", 81);  
            javaScriptKeys.Add("key_R", 82);  
            javaScriptKeys.Add("key_S", 83);  
            javaScriptKeys.Add("key_T", 84);  
            javaScriptKeys.Add("key_U", 85);  
            javaScriptKeys.Add("key_V", 86);  
            javaScriptKeys.Add("key_W", 87);  
            javaScriptKeys.Add("key_X", 88);  
            javaScriptKeys.Add("key_Y", 89);  
            javaScriptKeys.Add("key_Z", 90);  
            javaScriptKeys.Add("key_Num0", 48);  
            javaScriptKeys.Add("key_Num1", 49);  
            javaScriptKeys.Add("key_Num2", 50);  
            javaScriptKeys.Add("key_Num3", 51);  
            javaScriptKeys.Add("key_Num4", 52);  
            javaScriptKeys.Add("key_Num5", 53);  
            javaScriptKeys.Add("key_Num6", 54);  
            javaScriptKeys.Add("key_Num7", 55);  
            javaScriptKeys.Add("key_Num8", 56);  
            javaScriptKeys.Add("key_Num9", 57);  
            javaScriptKeys.Add("key_LControl", 17);  
            javaScriptKeys.Add("key_LShift", 16);  
            javaScriptKeys.Add("key_LAlt", 18);  
            javaScriptKeys.Add("key_RControl", 17);  
            javaScriptKeys.Add("key_RShift", 16);  
            javaScriptKeys.Add("key_RAlt", 18);  
            javaScriptKeys.Add("key_Escape", 27);  
            javaScriptKeys.Add("key_LBracket", 219);  
            javaScriptKeys.Add("key_RBracket", 221);  
            javaScriptKeys.Add("key_SemiColon", 186);
            javaScriptKeys.Add("key_Comma", 188);
            javaScriptKeys.Add("key_Period", 190);
            javaScriptKeys.Add("key_Quote", 222);
            javaScriptKeys.Add("key_Slash", 191);
            javaScriptKeys.Add("key_BackSlash", 220);
            javaScriptKeys.Add("key_Tilde", 192);
            javaScriptKeys.Add("key_Equal", 187);
            javaScriptKeys.Add("key_Dash", 189);
            javaScriptKeys.Add("key_Space", 32);
            javaScriptKeys.Add("key_Return", 13);
            javaScriptKeys.Add("key_Backspace", 8);
            javaScriptKeys.Add("key_Tab", 9);
            javaScriptKeys.Add("key_PageUp", 33);
            javaScriptKeys.Add("key_PageDown", 34);
            javaScriptKeys.Add("key_End", 35);
            javaScriptKeys.Add("key_Home", 36);
            javaScriptKeys.Add("key_Insert", 45);
            javaScriptKeys.Add("key_Delete", 46);
            javaScriptKeys.Add("key_Add", 107);
            javaScriptKeys.Add("key_Subtract", 109);
            javaScriptKeys.Add("key_Multiply", 106);
            javaScriptKeys.Add("key_Divide", 111);
            javaScriptKeys.Add("key_Left", 37);
            javaScriptKeys.Add("key_Right", 39);
            javaScriptKeys.Add("key_Up", 38);
            javaScriptKeys.Add("key_Down", 40);
            javaScriptKeys.Add("key_Numpad0", 96);
            javaScriptKeys.Add("key_Numpad1", 97);
            javaScriptKeys.Add("key_Numpad2", 98);
            javaScriptKeys.Add("key_Numpad3", 99);
            javaScriptKeys.Add("key_Numpad4", 100);
            javaScriptKeys.Add("key_Numpad5", 101);
            javaScriptKeys.Add("key_Numpad6", 102);
            javaScriptKeys.Add("key_Numpad7", 103);
            javaScriptKeys.Add("key_Numpad8", 104);
            javaScriptKeys.Add("key_Numpad9", 105);
            javaScriptKeys.Add("key_F1", 112);
            javaScriptKeys.Add("key_F2", 113);
            javaScriptKeys.Add("key_F3", 114);
            javaScriptKeys.Add("key_F4", 115);
            javaScriptKeys.Add("key_F5", 116);
            javaScriptKeys.Add("key_F6", 117);
            javaScriptKeys.Add("key_F7", 118);
            javaScriptKeys.Add("key_F8", 119);
            javaScriptKeys.Add("key_F9", 120);
            javaScriptKeys.Add("key_F10", 121);
            javaScriptKeys.Add("key_F11", 122);
            javaScriptKeys.Add("key_F12", 123);

            foreach(KeyValuePair<string,string> cntrl in controlList.Controls)
            {

                controls.Add(cntrl.Key, javaScriptKeys[cntrl.Value]);
            }

        }
    }
}
