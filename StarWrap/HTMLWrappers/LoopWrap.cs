using System;
using System.Collections.Generic;
using System.Text;

using System.Html;

namespace StarWrap.Wrappers
{
    class LoopWrap : ILoopWrap
    {

        Action drawLoop;
        Func<bool> logicLoop;
        delegate bool LogicLoop();

        void HTMLDrawLoop(double time)
        {
            drawLoop();
            Window.RequestAnimationFrame(HTMLDrawLoop);
        }

        public void SetDrawWrap(DrawWrap _drawWrap)
        {

        }

        public void SetDrawLoop(Action _drawLoop)
        {
            drawLoop = _drawLoop;
  
        }

        public void SetLogicLoop(Func<bool> _logicLoop)
        {
            logicLoop = _logicLoop;

        }

        public void StartLoop()
        {
            Window.RequestAnimationFrame(HTMLDrawLoop);
            Window.SetInterval(logicLoop, 1000 / 30);
        }
    }
}
