using System;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public interface IGameState
    {
        public SignType CurrentSign { get; }
        public void SwitchTurn();
        public event Action<SignType> OnSignSwitched;
    }
}