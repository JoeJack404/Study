﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class BotEasy : IBot
    {
        public int MoveBot(int numberOfStones, int movePlayer)
        {
            var move = new Random();
            if (numberOfStones > 4)
            {
                return move.Next(1, 4);
            }
            else if (numberOfStones > 1)
            {
                return move.Next(1, numberOfStones + 1);
            }
            else
            {
                return 0;
            }
        }
    }
}