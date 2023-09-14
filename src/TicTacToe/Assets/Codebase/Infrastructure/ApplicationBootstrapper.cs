using TicTacToe.Codebase.Infrastructure.StateMachine;
using Zenject;

namespace TicTacToe.Codebase.Infrastructure
{
    public class ApplicationBootstrapper : IInitializable
    {
        private readonly IApplicationStateMachine _appStateMachine;

        public ApplicationBootstrapper(IApplicationStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        public void Initialize()
        {
            _appStateMachine.Enter<BootstrapState>();
        }
    }
}