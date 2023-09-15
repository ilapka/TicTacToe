namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class BootstrapState : ApplicationState
    {
        private readonly SceneLoader _sceneLoader;
        
        public BootstrapState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter(IStateArgs args = null)
        {
            if (_sceneLoader.CurrentScene != Scenes.Initial)
            {
                _sceneLoader.Load(Scenes.Initial, onLoaded: EnterLoadProgress);
            }
            else
            {
                EnterLoadProgress();
            }
        }

        private void EnterLoadProgress()
        {
            AppStateMachine.Enter<LoadProgressState>();
        }
        
        public override void Exit()
        {
            
        }
    }
}