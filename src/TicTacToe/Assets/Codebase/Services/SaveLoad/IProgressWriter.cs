using TicTacToe.Codebase.Data;

namespace TicTacToe.Codebase.Services.SaveLoad
{
    public interface IProgressWriter
    {
        public void UpdateProgress(PlayerProgress progress);
    }
}