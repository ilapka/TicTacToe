using TicTacToe.Codebase.Services.UI;
using TicTacToe.Codebase.UI.Elements;

namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class LoadLevelState : ApplicationState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IUiService _uiService;

        private LoadLevelStateArgs _currentArgs;

        public LoadLevelState(SceneLoader sceneLoader, IUiService uiService)
        {
            _sceneLoader = sceneLoader;
            _uiService = uiService;
        }

        public override void Enter(IStateArgs args)
        {
            if (args != null)
            {
                _currentArgs = (LoadLevelStateArgs)args;
            }

            _uiService.FadeIn();

            _sceneLoader.Load(_currentArgs.LevelSceneName, OnLoaded);
        }

        public override void Exit()
        {
            _uiService.OpenWindow<HudScreen>();
            _uiService.FadeOut();
            _currentArgs = null;
        }

        private async void OnLoaded()
        {
            AppStateMachine.Enter<GameLoopState>();
        }
    }
}