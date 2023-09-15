namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class LoadLevelStateArgs : IStateArgs
    {
        public string LevelSceneName { get; }

        public LoadLevelStateArgs(string levelSceneName)
        {
            LevelSceneName = levelSceneName;
        }
    }
}