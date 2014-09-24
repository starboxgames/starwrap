using System;
using System.Collections.Generic;
using System.Text;

using StarWrap.Wrappers;

namespace Example
{
    // to compile for SFML include only the SFML wrappers and interface I*.cs files and add references to SFML.Net

    // to compile for JS/HTML install Saltarelle Packages and include only the HTML wrappers and the interface files
    // Saltarelle is a compiler which translates C# into JavaScript
    // http://saltarelle-compiler.com



    class ExampleGame
    {
        IDrawWrap drawWrap = new DrawWrap();
        IControlWrap controlWrap = new ControlWrap();
        ILoopWrap loopWrap = new LoopWrap();
        ISoundWrap soundWrap = new SoundWrap();

        bool gameLoaded = false;

        bool LogicLoop()
        {
            if (soundWrap.AllLoaded && !soundWrap.LoadingFailed)
                if (drawWrap.AllLoaded && !drawWrap.LoadingFailed)
                {

                    if (!gameLoaded)
                    {
                        gameLoaded = true;
                        soundWrap.PlaySound("start");
                    }
                }


            if (gameLoaded)
            {
                /// do your game logic stuff here

                if (controlWrap.IsKeyPressed("quit"))
                {
                    soundWrap.PlaySound("quit");
                    return false; // stop the loop and close the window - only works for SFML
                }
            }

            return true; // returning true means the loop will continue
        }


        void DrawLoop()
        {
            if (gameLoaded)
            {
                drawWrap.Draw("player", 32, 32);
                drawWrap.Draw("enemy", 128, 32);

            }
        }

        void Init()
        {


            drawWrap.AddImage("player", "player.png");
            drawWrap.AddImage("enemy", "enemy.png");

            drawWrap.LoadImages();

            soundWrap.AddSound("start", "start.wav");
            soundWrap.AddSound("quit", "quit.wav");

            soundWrap.LoadSounds();

            controlWrap.AddButton("jump", "key_Space");
            controlWrap.AddButton("quit", "key_Escape");

            controlWrap.ApplyControls();

            loopWrap.SetDrawWrap(drawWrap);

            loopWrap.SetDrawLoop(DrawLoop);
            loopWrap.SetLogicLoop(LogicLoop);

            loopWrap.StartLoop();
        }

        static void Main()
        {
        //    jQuery.OnDocumentReady(Init); // use this line for JS, you need to add "using jQueryApi" and install jQuery package for Saltarelle

         //   Init(); // use this line for SFML
        }
    }
}
