using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class BotEasy : IForBot
    {
        public int MoveBot(int numberOfStones, int movePlayer)
        {
            var move = new Random();
            if (numberOfStones > 4)
            {
                return numberOfStones - move.Next(0, 4);
            }
            else
            {
                return numberOfStones - move.Next(0, numberOfStones + 1);
            }
        }
    }
}