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
        public PreviousMoveEnum PreviousMove { get; private set; }
        public bool GameOver { get { return CurrentNumberOfStones == 0; } }

        public Game(string player, int number = 21)
        {
            NumberOfStones = number;
            Player = player;
            CurrentNumberOfStones = number;
            PreviousMove = PreviousMoveEnum.None;
        }

        public MoveResponse BotMove()
        {
            MoveResponse moveResponce = new MoveResponse();
            try
            {
                if (!GameOver)
                {
                    if (PreviousMove != PreviousMoveEnum.Bot)
                    {
                        int moveBot = Bot.MoveBot(CurrentNumberOfStones);
                        CurrentNumberOfStones = CurrentNumberOfStones - moveBot;
                        CurrentMoveBot = moveBot;
                        PreviousMove = PreviousMoveEnum.Bot;
                        moveResponce.Error = MoveErrorEnum.None;
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
                return moveResponce;
            }
            catch(Exception ex)
            {
                switch (ex)
                {
                    case GameOverException:
                        {
                            moveResponce.Error = MoveErrorEnum.GameOverError;
                            break;
                        }
                    case MoveOrderException:
                        {
                            moveResponce.Error = MoveErrorEnum.MoveOrderError;
                            break;
                        }
                }
                return moveResponce;

            }
        }

        public MoveResponse PlayerMove(int playerMove)
        {
            MoveResponse moveResponse = new MoveResponse();
            try
            {
                if (!GameOver)
                {
                    if (playerMove < 4)
                    {
                        if (playerMove < CurrentNumberOfStones)
                        {
                            if (PreviousMove != PreviousMoveEnum.Player)
                            {
                                CurrentNumberOfStones = CurrentNumberOfStones - playerMove;
                                PreviousMove = PreviousMoveEnum.Player;
                                moveResponse.Error = MoveErrorEnum.None;
                            }
                            else
                            {
                                throw new MoveOrderException();
                            }
                        }
                        else
                        {
                            throw new MoveStonesTakenThanLeftException();
                        }
                    }
                    else
                    {
                        throw new MoreStonesTakenThanAllowedException();
                    }
                }
                else
                {
                    throw new GameOverException();
                }
                return moveResponse;
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case GameOverException:
                        {
                            moveResponse.Error = MoveErrorEnum.GameOverError;
                            break;
                        }
                    case MoreStonesTakenThanAllowedException:
                        {
                            moveResponse.Error = MoveErrorEnum.MoreStonesTakenThanAllowed;
                            break;
                        }
                    case MoveStonesTakenThanLeftException:
                        {
                            moveResponse.Error = MoveErrorEnum.MoreStonesTakenThanLeft;
                            break;
                        }
                    case MoveOrderException:
                        {
                            moveResponse.Error = MoveErrorEnum.MoveOrderError;
                            break;
                        }
                }
                return moveResponse;
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
