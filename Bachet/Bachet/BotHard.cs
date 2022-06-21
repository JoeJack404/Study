using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class BotHard : IBot
    {
        public int MoveBot(int currentNumberOfStones)
        {
            if (currentNumberOfStones % 4 == 0)
            {
                return 3;
            }
            else if (currentNumberOfStones % 4 == 1 ^ currentNumberOfStones % 4 == 2)
            {
                return 1;
            }
            else 
            {
                return 2;
            }
        }
    }
}
