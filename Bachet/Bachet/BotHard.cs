namespace Bachet
{
    class BotHard : IBot
    {
    /// <summary>
    /// Ход бота.
    /// </summary>
    /// <param name="currentNumberOfStones">Количество оставщихся камней.</param>
    /// <returns>Сколько камней берет бот.</returns>
        public int MoveBot(int currentNumberOfStones)
        {
            if (currentNumberOfStones % 4 == 0)
            {
                return 3;
            }
            else if (currentNumberOfStones % 4 == 1 ^ currentNumberOfStones % 4 == 2)
            {
                return 1;
            }
            else 
            {
                return 2;
            }
        }
    }
}
