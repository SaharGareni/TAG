using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public interface IRoomActions
    {
        void Enter();
        void Exit();
        string Go(string target,GameState gameState);
    }
}
