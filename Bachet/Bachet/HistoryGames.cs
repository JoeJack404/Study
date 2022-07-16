﻿using System.IO;
using System.Text;

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
                string line = CurrentGame.PlayerName + " " + CurrentGame.NumberOfStones + " " + CurrentGame.Bot + "\n";
                byte[] lineByte = Encoding.Default.GetBytes(line);
                historyFile.Write(lineByte);
            }
        }

        //public async void LoadHistoryGames()
        //{
        //    string path = @"";
        //    using (FileStream historyFile = File.OpenRead(path))
        //    {
        //        byte[] buffer = new byte[historyFile.Length];
        //        await historyFile.ReadAsync(buffer, 0, buffer.Length);
        //        string textFromFile = Encoding.Default.GetString(buffer);
        //    }
        //}
    }
}
