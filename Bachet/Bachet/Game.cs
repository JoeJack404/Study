using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class Game
    {
        public IForBot Bot { get; set; }
        public int NumberOfStones { get; set; }

        public Game(IForBot bot, int number)
        {
            Bot = bot;
            NumberOfStones = number;
        }

        public void Move(int number, int movePlayer)
        {
            NumberOfStones = Bot.MoveBot(number, movePlayer);
        }
    }
}
