using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class BotEasy : IBot
    {
        /// <summary>
        /// Ход бота.
        /// </summary>
        /// <param name="currentNumberOfStones">Количество оставшихся камней.</param>
        /// <returns>Сколько камней берет бот.</returns>
        public int MoveBot(int currentNumberOfStones)
        {
            var move = new Random();
            if (currentNumberOfStones > 4)
            {
                return move.Next(1, 4);
            }
            else if (currentNumberOfStones > 1)
            {
                return move.Next(1, currentNumberOfStones + 1);
            }
            else
            {
                return 0;
            }
        }
    }
}