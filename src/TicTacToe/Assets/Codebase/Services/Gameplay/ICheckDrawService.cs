using System;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public interface ICheckDrawService
    {
        public event Action OnDraw;
    }
}