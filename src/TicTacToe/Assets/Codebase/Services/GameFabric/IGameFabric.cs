using TicTacToe.Codebase.Services.Gameplay;
using UnityEngine;

namespace TicTacToe.Codebase.Services.GameFabric
{
    public interface IGameFabric
    {
        public CellView CreateCell(Transform root, Vector2 position);
    }
}