using TicTacToe.Codebase.Data;

namespace TicTacToe.Codebase.Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        GameProgress GameProgress { get; set; }
    }
}