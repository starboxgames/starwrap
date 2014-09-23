using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap.Managers
{
    class LoopMan : ILoopMan
    {
        //delegate bool LogicLoop();

        Action drawLoop;
        Func<bool> logicLoop;

        DrawMan drawMan;

        public void SetDrawMan(DrawMan _drawMan)
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
