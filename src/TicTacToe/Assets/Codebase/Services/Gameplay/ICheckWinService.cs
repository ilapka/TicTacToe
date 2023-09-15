using System;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public interface ICheckWinService
    {
        public event Action<SignType> OnWin;
    }
}