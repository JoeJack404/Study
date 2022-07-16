using System;

namespace Bachet
{
    class Game
    {
        public IBot Bot { get; private set; }
        public int NumberOfStones { get; private set; }
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string PlayerName { get; private set; }     //Будет необходимо для истории игры//
        public int CurrentNumberOfStones { get; private set; }
        public int CurrentMoveBot { get; private set; }
        public PreviousMoveEnum PreviousMove { get; private set; }
        public bool GameOver { get { return CurrentNumberOfStones == 0; } }

        public Game(string player, int number = 21)
        {
            NumberOfStones = number;
            PlayerName = player;
            CurrentNumberOfStones = number;
            PreviousMove = PreviousMoveEnum.None;
        }
        /// <summary>
        /// Ход игры.
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        public MoveResponse BotMove()
        {
            MoveResponse moveResponce = new();
            try
            {
                if (Bot != null)
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
                            throw new MoveOrderException("Неправильный порядок хода");
                        }
                    }
                    else
                    {
                        throw new GameOverException("Игра закончилась");
                    }
                }
                else
                {
                    throw new BotIsNotCreatedException("Бот не создан");
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
                    case BotIsNotCreatedException:
                        {
                            moveResponce.Error = MoveErrorEnum.BotIsNotCreated;
                            break;
                        }
                }
                return moveResponce;

            }
        }
        /// <summary>
        /// Ход игрока.
        /// </summary>
        /// <param name="playerMove">Количество взятых камней.</param>
        /// <returns>Сообщение об ошибке.</returns>
        public MoveResponse PlayerMove(int playerMove)
        {
            MoveResponse moveResponse = new();
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
                                throw new MoveOrderException("Неправильный порядок хода");
                            }
                        }
                        else
                        {
                            throw new MoveStonesTakenThanLeftException("Больше камней, чем осталось");
                        }
                    }
                    else
                    {
                        throw new MoreStonesTakenThanAllowedException("Больше камней, чем можно взять");
                    }
                }
                else
                {
                    throw new GameOverException("Игра закончилась");
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
        /// <summary>
        /// Создает сложного бота.
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        public CreateBotResponce CreateBotHard()
        {
            CreateBotResponce createBotResponce = new CreateBotResponce();
            try
            {
                if (Bot == null)
                {
                    BotHard botHard = new BotHard();
                    Bot = botHard;
                    createBotResponce.Error = CreateBotErrorEnum.None;
                }
                else
                {
                    throw new CreateBotException("Бот уже создан");
                }
                return createBotResponce;
            }
            catch (CreateBotException)
            {
                createBotResponce.Error = CreateBotErrorEnum.BotAlreadyCreatedError;
                return createBotResponce;
            }
        }
        /// <summary>
        /// Создает простого бота.
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        public CreateBotResponce CreateBotEasy()
        {
            CreateBotResponce createBotResponce = new CreateBotResponce();
            try
            {
                if (Bot == null)
                {
                    BotEasy botEasy = new BotEasy();
                    Bot = botEasy;
                    createBotResponce.Error = CreateBotErrorEnum.None;
                }
                else
                {
                    throw new CreateBotException("Бот уже создан");
                }
                return createBotResponce;
            }
            catch (CreateBotException)
            {
                createBotResponce.Error = CreateBotErrorEnum.BotAlreadyCreatedError;
                return createBotResponce;
            }
        }
    }
}
