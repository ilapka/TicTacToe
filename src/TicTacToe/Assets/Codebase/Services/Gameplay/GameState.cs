namespace TicTacToe.Codebase.Services.Gameplay
{
    public class GameState : IGameState
    {
        public SignType CurrentSign { get; private set; } = SignType.Cross;

        public void SwitchTurn()
        {
            CurrentSign =
                CurrentSign == SignType.Cross ?
                SignType.Ring :
                SignType.Cross;
        }
    }
}