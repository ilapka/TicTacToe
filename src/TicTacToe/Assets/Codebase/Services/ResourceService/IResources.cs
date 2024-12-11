using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.UI.Gameplay;

namespace TicTacToe.Codebase.Services.ResourceService
{
    public interface IResources
    {
        public CellView LoadCell();
    }
}