using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Bachet
{
    class HistoryGames
    {
        public Game CurrentGame { get; set; }
        public HistoryGames(Game currentGame)
        {
            CurrentGame = currentGame;
        }
        public void SaveHistoryGame()
        {
            using (FileStream historyFile = new FileStream("BachetHistory.txt", FileMode.OpenOrCreate))
            {
                byte[] player = Encoding.Default.GetBytes(CurrentGame.Player);
                byte[] lineBreak = Encoding.Default.GetBytes("\n");
                byte[] space = Encoding.Default.GetBytes(" ");
                historyFile.Write(player);
                historyFile.Write(space);
                historyFile.Write(lineBreak);
            }
        }

        public async void LoadHistoryGames()
        {
            string path = @"";
            using (FileStream historyFile = File.OpenRead(path))
            {
                byte[] buffer = new byte[historyFile.Length];
                await historyFile.ReadAsync(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
            }
        }
    }
}
