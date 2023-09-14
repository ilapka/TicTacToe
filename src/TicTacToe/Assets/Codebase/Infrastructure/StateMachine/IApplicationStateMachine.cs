namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public interface IApplicationStateMachine
    {
        void Enter<TState>(StateArgs args = null) where TState : ApplicationState;
    }
}