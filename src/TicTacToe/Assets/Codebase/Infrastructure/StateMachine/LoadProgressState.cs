using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.PersistentProgress;
using TicTacToe.Codebase.Services.SaveLoad;

namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class LoadProgressState : ApplicationState
    { 
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly GameSettings _gameSettings;

        public LoadProgressState(IPersistentProgressService progressService, ISaveLoadService saveLoadService, GameSettings gameSettings)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _gameSettings = gameSettings;
        }

        public override void Enter(IStateArgs args = null)
        {
            LoadProgressOrInitNew();

            LoadLevelStateArgs loadLevelArgs = new LoadLevelStateArgs(Scenes.Game);
            AppStateMachine.Enter<LoadLevelState>(loadLevelArgs);
        }

        public override void Exit()
        {
          
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress()
            {
                Settings = _gameSettings.DefaultFieldSettigns,
            };
        }
    }
}