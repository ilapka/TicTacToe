using TicTacToe.Codebase.Data;

namespace TicTacToe.Codebase.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}