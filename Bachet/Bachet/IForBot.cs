using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    interface IForBot
    {
        public int MoveBot(int numberOfStones, int movePlayer)
        {
            return numberOfStones;
        }
    }
}
