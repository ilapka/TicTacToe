using System;
using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.Services.UI;

namespace TicTacToe.Codebase.UI.Elements
{
    public class WinScreenArgs : UiArgs
    {
        public SignType WinnerSign { get; }
        public Action OnCloseCallback { get; }

        public WinScreenArgs(SignType winnerSign, Action onCloseCallback)
        {
            WinnerSign = winnerSign;
            OnCloseCallback = onCloseCallback;
        }
    }
}