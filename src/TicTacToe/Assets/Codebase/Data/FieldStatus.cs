using System;
using TicTacToe.Codebase.Services.Gameplay;

namespace TicTacToe.Codebase.Data
{
    [Serializable]
    public class FieldStatus
    {
        public SignType CurrentSign;
        public Cell[] Cells;
    }
}