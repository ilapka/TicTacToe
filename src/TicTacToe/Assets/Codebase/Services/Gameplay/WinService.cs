using System;
using TicTacToe.Codebase.Services.UI;
using TicTacToe.Codebase.UI.Elements;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class WinService : IWinService, IDisposable
    {
        private readonly ICheckWinService _checkWinService;
        private readonly IUiService _uiService;

        public WinService(ICheckWinService checkWinService, IUiService uiService)
        {
            _checkWinService = checkWinService;
            _uiService = uiService;
            
            _checkWinService.OnWin += OnWinHandler;
        }

        private void OnWinHandler(SignType signType)
        {
            WinScreenArgs args = new WinScreenArgs(signType, RestartLevel);
            _uiService.OpenWindow<WinScreen>(args);
        }

        private void RestartLevel()
        {
            //Reset progress in save load service
            //Restart game from load level state (or some of this states)
        }

        public void Dispose()
        {
            _checkWinService.OnWin -= OnWinHandler;
        }
    }
}