using TicTacToe.Codebase.Data;

namespace TicTacToe.Codebase.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}