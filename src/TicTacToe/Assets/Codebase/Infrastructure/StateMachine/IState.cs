namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public interface IState
    {
        void Enter(StateArgs args = null);
        void Exit();
    }
}