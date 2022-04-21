using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class BotHard : IForBot
    {
        public int MoveBot(int numberOfStones, int movePlayer)
        {
            if (numberOfStones > 4)
            {
                int move = 4 - movePlayer;
                return numberOfStones - move;
            }
            else
            {
                return 1;
            }
        }
    }
}
