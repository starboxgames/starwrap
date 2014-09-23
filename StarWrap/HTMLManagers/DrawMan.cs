using System;
using System.Collections.Generic;
using System.Text;
using System.Html;
using System.Html.Media.Graphics;

using System.Runtime.CompilerServices;

namespace StarWrap.Managers
{
    class DrawMan : IDrawMan
    {
        Dictionary<string, ImageElement> images = new Dictionary<string,ImageElement>();
        
        CanvasElement canvas;
        CanvasRenderingContext2D context;
        CanvasRenderingContext2D bgContext;

        CanvasElement bgCanvas;

        public bool AllLoaded { get; set; }
        public bool LoadingFailed { get; set; }        

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        
        
        public int NumImagesLoaded { get { return numImagesLoaded; } }
        public int NumImages { get { return numImages; } }

        int numImages = -1;
        int numImagesLoaded = 0;

        int width;
        int height;

        public DrawMan()
        {
            AllLoaded = false;
            LoadingFailed = false;

            canvas = (CanvasElement)Document.GetElementById("canvas");
            context = (CanvasRenderingContext2D)canvas.GetContext(CanvasContextId.Render2D);

            bgCanvas = (CanvasElement)Document.CreateElement("canvas");
            bgCanvas.Width = canvas.Width * 10;
            bgCanvas.Height = canvas.Height * 2;

            bgContext = (CanvasRenderingContext2D)bgCanvas.GetContext(CanvasContextId.Render2D);

            //Document.Body.AppendChild(bgCanvas);

            width = canvas.Width;
            height = canvas.Height;
        }

        public void Clear()
        {
            context.SetTransform(1, 0, 0, 1, 0, 0);

            context.FillStyle = "#000000";
            context.FillRect(0, 0, canvas.Width, canvas.Height);
        }

        public void Display()
        {

        }


        public void Draw(string name, int x, int y, bool mirrored = false, float scaleX = 1, float scaleY = 1, 
                        int originX = 0, int originY = 0, int rotation = 0,
                        int sx = 0, int sy = 0, int sw = -1, int sh = -1, bool drawOutside = false)
        {


            if (!(x < -32 || x > Width + 32 || y < -32 || y > Height + 32) || drawOutside)
            {
                ImageElement img;

                images.TryGetValue(name, out img);

                context.SetTransform(1, 0, 0, 1, 0, 0);

                context.Translate(x, y);

               

                if (sw == -1) sw = img.Width;
                if (sh == -1) sh = img.Height;

                if (!mirrored)
                {
                    context.Scale(scaleX, scaleY);

                    if (rotation != 0) context.Rotate(rotation * Math.PI / 180);

                    context.DrawImage(image: img, sx: sx, sy: sy, sw: sw, sh: sh, dx: -originX, dy: -originY, dw: sw, dh: sh);
                }
                else
                {
                    if (rotation != 0) context.Rotate(-rotation * Math.PI / 180);

                    context.Scale(-1 * scaleX, scaleY);

                    

                    context.DrawImage(image: img, sx: sx, sy: sy, sw: sw, sh: sh, dx: -img.Width + originX, dy: -originY, dw: sw, dh: sh);

                }
            }
        }

        [InlineCode("this.$context.textBaseline = {baseline}")]
        void ContextTextBaseline(string baseline)
        {

        }


        [InlineCode("this.$context.textAlign = {align}")]
        void ContextTextAlign(string align)
        {

        }

        public void DrawText(int x, int y, string text, 
                            string color = "#FFF", string baseLine = "center", 
                            string align = "center")
        {
            context.SetTransform(1, 0, 0, 1, 0, 0);

            context.Translate(x, y);

            ContextTextBaseline(baseLine);
            ContextTextAlign(align);

            context.Font = "12px Verdana";            
            context.FillStyle = color;
            
            context.FillText(text, 0, 0);
        }

        void OnError(Event e)
        {
            LoadingFailed = true;
        }

        void OnLoad(Event e)
        {
            numImagesLoaded++;

            if (numImagesLoaded == numImages) AllLoaded = true;
        }

        void AddImage(string name, string location)
        {
            ImageElement img;

            img = (ImageElement)Document.CreateElement("img");
            img.SetAttribute("src", location);
            img.OnLoad = OnLoad;
            img.OnError = OnError;

            images.Add(name, img);
        }

        public void LoadImages()
        {

            numImages = -1;

            ImageList imageList = new ImageList();

            foreach(KeyValuePair<string,string> imgname in imageList.Images)
            {
                AddImage(imgname.Key, imgname.Value);
            }

            numImages = images.Count;
        }
    }
}
