using System;
using System.Collections.Generic;
using System.Text;

namespace StarWrap
{
    class ImageList
    {
        public Dictionary<string, string> Images = new Dictionary<string, string>();

        public ImageList()
        {
            Images.Add("placeholder", "gfx/placeholder.png");

            Images.Add("player", "gfx/player.png");
            Images.Add("playerwalk0", "gfx/playerwalk0.png");
            Images.Add("playerwalk1", "gfx/playerwalk1.png");
            Images.Add("playerwalk2", "gfx/playerwalk2.png");
            Images.Add("playerwalk3", "gfx/playerwalk3.png");
            Images.Add("playerfall0", "gfx/playerfall0.png");
            Images.Add("playerfall1", "gfx/playerfall1.png");

            Images.Add("wall", "gfx/block.png");
            Images.Add("ground", "gfx/ground.png");
            Images.Add("ground2", "gfx/ground2.png");
            Images.Add("bridge", "gfx/bridge.png");
            Images.Add("fence", "gfx/fence.png");

            Images.Add("box", "gfx/box.png");

            Images.Add("bg", "gfx/bg.png");
            Images.Add("bg2", "gfx/bg2.png");

            Images.Add("boomerang", "gfx/boomerang.png");

            Images.Add("enemy", "gfx/enemy.png");
            Images.Add("enemywalk0", "gfx/enemywalk0.png");
            Images.Add("enemywalk1", "gfx/enemywalk1.png");
            Images.Add("enemywalk2", "gfx/enemywalk2.png");
            Images.Add("enemywalk3", "gfx/enemywalk3.png");
            Images.Add("enemyfall0", "gfx/enemyfall0.png");
            Images.Add("enemyfall1", "gfx/enemyfall1.png");

            Images.Add("aithought", "gfx/aithought.png");
            Images.Add("aithought2", "gfx/aithought2.png");
        }
    }
}
