using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;

namespace StarWrap.Managers
{
    class DrawMan : IDrawMan
    {
        RenderWindow window;
        RenderTexture buffer;
        Sprite bufferSpr = new Sprite();

        public int Width { get; set; }
        public int Height { get; set; }

        public bool AllLoaded { get; set; }
        public bool LoadingFailed { get; set; }       
 
        public void DispatchWindow()
        {
            window.DispatchEvents();
        }

        public DrawMan()
        {
            Width = 640;
            Height = 360;

            window = new RenderWindow(new VideoMode(960, 540),
                    "Duck Emergency", Styles.Titlebar);

            window.SetFramerateLimit(30);
            window.SetVisible(true);

            AllLoaded = false;
            LoadingFailed = false;

            buffer = new RenderTexture((uint)Width, (uint)Height);

            bufferSpr.Texture = buffer.Texture;
            bufferSpr.Scale = new Vector2f(960f / (float)Width, 540f / (float)Height);
        }

        public void Clear()
        {
            buffer.Clear();
        }

        public void DrawText(int x, int y, string text, 
                            string color = "#FFF", string baseLine = "center", 
                            string align = "center")
        {

        }

        Sprite spr = new Sprite();

        public void Draw(string name, int x, int y, bool mirrored = false, float scaleX = 1, float scaleY = 1, 
                        int originX = 0, int originY = 0, int rotation = 0,
                        int sx = 0, int sy = 0, int sw = -1, int sh = -1, bool drawOutside = false)
        {
            Texture tex;

            textures.TryGetValue(name, out tex);

            int w = sw;
            int h = sh;

            if (w == -1) w = (int)tex.Size.X - sx;
            if (h == -1) h = (int)tex.Size.Y - sx;

            spr.TextureRect = new IntRect(sx, sy, w, h);

            spr.Texture = tex;
            spr.Position = new Vector2f((float)x, (float)y);
            spr.Scale = new Vector2f(scaleX, scaleY);

            spr.Origin = new Vector2f(originX, originY);

            if (mirrored)
            {
                spr.Scale = new Vector2f(spr.Scale.X * -1, spr.Scale.Y);
            }

            spr.Rotation = rotation;

            buffer.Draw(spr);
        }

        public void Display()
        {
            buffer.Display();

            window.Draw(bufferSpr);
            window.Display();
        }

        Dictionary<string, Texture> textures = new Dictionary<string,Texture>();

        public void LoadImages()
        {
            ImageList imageList = new ImageList();

            AllLoaded = true;
            LoadingFailed = false;

            foreach(KeyValuePair<string,string> imgname in imageList.Images)
            {
                try
                {
                    textures.Add(imgname.Key, new Texture(imgname.Value));
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
