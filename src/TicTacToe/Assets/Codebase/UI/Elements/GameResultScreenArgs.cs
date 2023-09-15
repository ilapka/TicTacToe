using System;
using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.Services.UI;

namespace TicTacToe.Codebase.UI.Elements
{
    public class GameResultScreenArgs : UiArgs
    {
        public SignType WinnerSign { get; }
        public Action OnCloseCallback { get; }

        public GameResultScreenArgs(SignType winnerSign, Action onCloseCallback)
        {
            WinnerSign = winnerSign;
            OnCloseCallback = onCloseCallback;
        }
    }
}