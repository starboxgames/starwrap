using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap.Wrappers
{
    class LoopWrap : ILoopWrap
    {
        //delegate bool LogicLoop();

        Action drawLoop;
        Func<bool> logicLoop;

        DrawWrap drawMan;

        public void SetDrawWrap(DrawWrap _drawMan)
        {
            drawMan = _drawMan;
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
            while (true)
            {
                drawLoop();
                drawMan.Display();
                drawMan.DispatchWindow();
                if (!logicLoop()) break;
            }
        }
    }
}
