using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.PersistentProgress;
using TicTacToe.Codebase.Services.SaveLoad;

namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class LoadProgressState : ApplicationState
    { 
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
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
            _progressService.GameProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private GameProgress NewProgress()
        {
            return GameProgress.DefaultPreset;
        }
    }
}