namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class LoadLevelStateArgs : StateArgs
    {
        public string LevelSceneName { get; }

        public LoadLevelStateArgs(string levelSceneName)
        {
            LevelSceneName = levelSceneName;
        }
    }
}