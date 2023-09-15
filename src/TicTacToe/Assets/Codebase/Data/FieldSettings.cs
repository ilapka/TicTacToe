using System;

namespace TicTacToe.Codebase.Data
{
    [Serializable]
    public class FieldSettings
    {
        public int FieldWidth = 3;
        public int FieldHeight = 3;
        public int ChainLenght = 3;
    }
}