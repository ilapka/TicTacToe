using System;

namespace TicTacToe.Codebase.Data
{
    [Serializable]
    public class GameProgress
    {
        public GameConfiguration Configuration;
        
        public static GameProgress DefaultPreset = new GameProgress()
        {
            Configuration = new GameConfiguration()
            {
                FieldWidth = 3,
                FieldHeight = 3,
                ChainLenght = 3,
            }
        };
    }
}