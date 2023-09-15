using TicTacToe.Codebase.Services.Gameplay;

namespace TicTacToe.Codebase.Services.ResourceService
{
    public interface IResources
    {
        public CellView LoadCell();
    }
}