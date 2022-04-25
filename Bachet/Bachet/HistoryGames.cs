using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Bachet
{
    class HistoryGames
    {
        public Game CurrentGame { get; set; }
        public HistoryGames(Game currentGame)
        {
            CurrentGame = currentGame;
        }
    }
}
