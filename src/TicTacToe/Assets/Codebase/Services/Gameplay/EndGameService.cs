using System;
using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Infrastructure;
using TicTacToe.Codebase.Services.SaveLoad;
using TicTacToe.Codebase.Services.UI;
using TicTacToe.Codebase.UI.Elements;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class EndGameService : IEndGameService, IDisposable, IProgressWriter
    {
        private readonly ICheckWinService _checkWinService;
        private readonly ICheckDrawService _checkDrawService;
        private readonly IUiService _uiService;
        private readonly IRestartLevelService _restartService;
        private readonly ISaveLoadService _saveLoadService;

        private bool _isEndGame;
        
        public EndGameService(ICheckWinService checkWinService, ICheckDrawService checkDrawService,
            IUiService uiService, IRestartLevelService restartService, ISaveLoadService saveLoadService)
        {
            _checkWinService = checkWinService;
            _uiService = uiService;
            _restartService = restartService;
            _saveLoadService = saveLoadService;
            _checkDrawService = checkDrawService;

            _checkWinService.OnWin += OnWinHandler;
            _checkDrawService.OnDraw += OnDrawHandler;
            _saveLoadService.RegisterWriter(this);
        }

        private void OnWinHandler(SignType signType)
        {
            if(_isEndGame) return;
            _isEndGame = true;
            
            ShowResultWindow(signType);
        }
        
        private void OnDrawHandler()
        {
            if(_isEndGame) return;
            _isEndGame = true;

            ShowResultWindow(SignType.None);
        }

        private void ShowResultWindow(SignType signType)
        {
            GameResultScreenArgs args = new GameResultScreenArgs(signType, RestartLevel);
            _uiService.OpenWindow<GameResultScreen>(args);
        }

        private void RestartLevel()
        {
            _restartService.Restart();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.FieldStatus.IsGameComplete = _isEndGame;
        }

        public void Dispose()
        {
            _checkWinService.OnWin -= OnWinHandler;
            _checkDrawService.OnDraw -= OnDrawHandler;
            _saveLoadService.UnregisterWriter(this);
        }
    }
}