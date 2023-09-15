using System;
using UnityEngine;

namespace TicTacToe.Codebase.Services.Gameplay
{
    [Serializable]
    public class Cell
    {
        public Vector2Int Position;
        public SignType Sign;

        public Cell(Vector2Int position)
        {
            Position = position;
        }
    }
}