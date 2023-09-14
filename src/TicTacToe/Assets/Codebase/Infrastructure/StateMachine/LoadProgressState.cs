namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class LoadProgressState : ApplicationState
    { 
        //private readonly IPersistentProgressService _progressService;
        //private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState()//, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            // _progressService = progressService;
            // _saveLoadService = saveLoadService;
        }

        public override void Enter(StateArgs args = null)
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
            //_progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        // private PlayerProgress NewProgress()
        // {
        //     PlayerProgress progress = new PlayerProgress(initialLevel: Main);
        //
        //     progress.HeroState.MaxHP = 50;
        //     progress.HeroState.ResetHP();
        //     progress.HeroStats.Damage = 1f;
        //     progress.HeroStats.DamageRadius = 0.5f;
        //     
        //     return progress;
        // }
    }
}