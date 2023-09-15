using System;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public interface IGameFieldService
    {
        public Cell[][] Field { get; }
        public event Action OnFieldUpdate;
    }
}