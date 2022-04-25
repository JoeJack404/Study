using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Bachet
{
    class Game
    {
        public IBot Bot { get; set; }
        public int NumberOfStones { get; set; }
        public int Winner { get; set; }
        public string Player { get; set; }
        public Stopwatch GameTime { get; set; }

        public Game(IBot bot, string player, int number = 21)
        {
            Bot = bot;
            NumberOfStones = number;
            Player = player;
        }

        public int Move(int movePlayer)
        {
            int moveBot = Bot.MoveBot(NumberOfStones, movePlayer);
            NumberOfStones = NumberOfStones - moveBot;
            return moveBot;
        }

        public int GameFirstMoveBot()
        {
            GameTime = new Stopwatch();
            GameTime.Start();
            int movePlayer = 0;
            while(NumberOfStones != 0)
            {
                if (NumberOfStones == 1)
                {
                    NumberOfStones = 0;
                    Winner = 0;
                }
                else
                {
                    Move(movePlayer);
                    if (NumberOfStones == 0)
                    {
                        Winner = 0;
                    }
                    else
                    {
                        movePlayer = Convert.ToInt32(Console.ReadLine());
                        Winner = 1;
                    }
                }
            }
            GameTime.Stop();
            return Winner;
        }

        public void GameFirstMovePlayer()
        {

        }
    }
}
