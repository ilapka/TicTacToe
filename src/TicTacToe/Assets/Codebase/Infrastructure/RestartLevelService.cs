using TicTacToe.Codebase.Infrastructure.StateMachine;

namespace TicTacToe.Codebase.Infrastructure
{
    public class RestartLevelService : IRestartLevelService
    {
        private readonly IApplicationStateMachine _appStateMachine;

        public RestartLevelService(IApplicationStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        public void Restart()
        {
            _appStateMachine.Enter<LoadProgressState>();
        }
    }
}