namespace TicTacToe.Codebase.Services.Gameplay
{
    public interface IGameState
    {
        public SignType CurrentSign { get; }
        public void SwitchTurn();
    }
}