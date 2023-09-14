using TicTacToe.Codebase.Data;

namespace TicTacToe.Codebase.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public GameProgress GameProgress { get; set; }
    }
}