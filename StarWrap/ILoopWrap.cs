using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWrap.Wrappers
{

    interface ILoopWrap
    {
        void SetDrawWrap(DrawWrap _drawMan);
        void SetDrawLoop(Action _drawLoop);
        void SetLogicLoop(Func<bool> _logicLoop);
        void StartLoop();

    }
}
