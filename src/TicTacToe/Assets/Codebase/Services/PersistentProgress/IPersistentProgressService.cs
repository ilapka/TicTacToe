using TicTacToe.Codebase.Data;

namespace TicTacToe.Codebase.Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}