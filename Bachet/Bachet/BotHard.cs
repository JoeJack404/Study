﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class BotHard : IBot
    {
        public int MoveBot(int numberOfStones, int movePlayer)
        {
            if (numberOfStones > 4)
            {
                if (movePlayer == 0)
                {
                    return 1;
                }
                return 4 - movePlayer;
            }
            else if (numberOfStones > 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
