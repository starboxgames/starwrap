using System;
using System.Collections.Generic;
using System.Text;

using System.Html;

namespace StarWrap.Managers
{
    class LoopMan : ILoopMan
    {

        Action drawLoop;
        Func<bool> logicLoop;
        delegate bool LogicLoop();

        void HTMLDrawLoop(double time)
        {
            drawLoop();
            Window.RequestAnimationFrame(HTMLDrawLoop);
        }

        public void SetDrawMan(DrawMan _drawMan)
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
