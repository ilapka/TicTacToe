using System;

namespace TicTacToe.Codebase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public FieldSettings FieldSettings;
        public FieldStatus FieldStatus;
    }
}