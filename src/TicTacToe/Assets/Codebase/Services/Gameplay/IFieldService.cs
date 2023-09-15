using System;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public interface IFieldService
    {
        public Cell[][] Field { get; }
        public event Action OnFieldUpdate;
    }
}