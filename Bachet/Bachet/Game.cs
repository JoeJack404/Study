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

        public void GameFirstMoveBot()
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
                    int moveBot = Move(movePlayer);
                    if (NumberOfStones == 0)
                    {
                        Winner = 0;
                    }
                    else
                    {
                        Console.WriteLine("Компьютер взял {0} камешка, осталось {1}", moveBot, NumberOfStones);
                        Console.WriteLine("Сколько камней возьмете Вы?");
                        movePlayer = Convert.ToInt32(Console.ReadLine());
                        Winner = 1;
                    }
                }
            }
            GameTime.Stop();
        }

        public void GameFirstMovePlayer()
        {
            GameTime = new Stopwatch();
            GameTime.Start();
            while(NumberOfStones != 0)
            {
                if (NumberOfStones == 1)
                {
                    Winner = 1;
                }
                else
                {
                    Console.WriteLine("{0} камней осталось, Ваш ход", NumberOfStones);
                    int movePlayer = Convert.ToInt32(Console.ReadLine());
                    int moveBot = Move(movePlayer);
                    Console.WriteLine("Комньютер взял {0} камешка", moveBot);
                    Winner = 0;
                }
            }
            GameTime.Stop();
        }
    }
}
