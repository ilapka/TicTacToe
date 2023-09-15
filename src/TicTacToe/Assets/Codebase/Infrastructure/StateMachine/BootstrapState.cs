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
            _sceneLoader.Load(Scenes.Initial, onLoaded: EnterLoadProgress);
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