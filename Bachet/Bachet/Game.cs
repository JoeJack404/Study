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
        public IBot Bot { get; private set; }
        public int NumberOfStones { get; private set; }
        public string Player { get; private set; }
        public int CurrentNumberOfStones { get; private set; }
        public int CurrentMoveBot { get; private set; }
        public string PreviousMove { get; private set; }
        public bool GameOver { get { return CurrentNumberOfStones == 0; } }

        public Game(string player, int number = 21)
        {
            NumberOfStones = number;
            Player = player;
            CurrentNumberOfStones = number;
        }

        public void BotMove()
        {
            try
            {

                if (!GameOver)
                {
                    if (PreviousMove == null ^ PreviousMove == "Player")
                    {
                        int moveBot = Bot.MoveBot(CurrentNumberOfStones);
                        CurrentNumberOfStones = CurrentNumberOfStones - moveBot;
                        CurrentMoveBot = moveBot;
                        PreviousMove = "Bot";
                    }
                    else
                    {
                        throw new MoveOrderException();
                    }
                }
                else
                {
                    throw new GameOverException();
                }
            }
            catch(Exception ex)
            {
                if (ex is GameOverException)
                {

                }
            }
        }

        public void PlayerMove(int playerMove)
        {
            if (!GameOver)
            {
                if (playerMove < 4 & playerMove <= CurrentNumberOfStones)
                {
                    if (PreviousMove == null ^ PreviousMove == "Bot")
                    {
                        CurrentNumberOfStones = CurrentNumberOfStones - playerMove;
                        PreviousMove = "Player";
                    }
                }
            }
        }

        public void CreateBotHard()
        {
            if (Bot == null)
            {
                BotHard botHard = new BotHard();
                Bot = botHard;
            }
        }

        public void CreateBotEasy()
        {
            if (Bot == null)
            {
                BotEasy botEasy = new BotEasy();
                Bot = botEasy;
            }
        }
    }
}
