using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap.Managers
{
    interface IDrawMan
    {
        void LoadImages();
        void Display();

        void Draw(string name, int x, int y, bool mirrored = false, float scaleX = 1, float scaleY = 1,
                        int originX = 0, int originY = 0, int rotation = 0,
                        int sx = 0, int sy = 0, int sw = -1, int sh = -1, bool drawOutside = false);

        void DrawText(int x, int y, string text,
                            string color = "#FFF", string baseLine = "center",
                            string align = "center");
        void Clear();

        int Width { get; }
        int Height { get; }

        bool AllLoaded { get; set; }
        bool LoadingFailed { get; set; } 
    }
}
