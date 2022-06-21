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
        public string Player { get; set; }
        public int CurrentNumberOfStones { get; set; }
        public int CurrentBotMove { get; set; }
        public bool GameOver { get { return CurrentNumberOfStones == 0; } }

        public Game(string player, int number = 21)
        {
            NumberOfStones = number;
            Player = player;
            CurrentNumberOfStones = number;
        }

        public void BotMove()
        {
            int moveBot = Bot.MoveBot(CurrentNumberOfStones, NumberOfStones);
            CurrentNumberOfStones = CurrentNumberOfStones - moveBot;
            CurrentBotMove = moveBot;
        }

        public void PlayerMove(int playerMove)
        {
            CurrentNumberOfStones = CurrentNumberOfStones - playerMove;
        }

        public void CreateBotHard()
        {
            BotHard botHard = new BotHard();
            Bot = botHard;
        }

        public void CreateBotEasy()
        {
            BotEasy botEasy = new BotEasy();
            Bot = botEasy;
        }
    }
}
