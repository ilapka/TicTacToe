using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.UI.Gameplay;
using UnityEngine;

namespace TicTacToe.Codebase.Services.GameFactory
{
    public interface IGameFactory
    {
        public CellView CreateCell(Transform root, Vector2 position);
    }
}