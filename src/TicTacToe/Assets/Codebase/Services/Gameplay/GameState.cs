using System;
using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.PersistentProgress;
using TicTacToe.Codebase.Services.SaveLoad;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class GameState : IGameState, IProgressWriter, IDisposable
    {
        private readonly ISaveLoadService _saveLoadService;
        public SignType CurrentSign { get; private set; }
        public event Action<SignType> OnSignSwitched;

        public GameState(IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _saveLoadService.RegisterWriter(this);

            CurrentSign = progressService.PlayerProgress.FieldStatus.CurrentSign;
        }

        public void SwitchTurn()
        {
            CurrentSign =
                CurrentSign == SignType.Cross ?
                SignType.Ring :
                SignType.Cross;
            
            OnSignSwitched?.Invoke(CurrentSign);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.FieldStatus.CurrentSign = CurrentSign;
        }

        public void Dispose()
        {
            _saveLoadService.UnregisterWriter(this);
        }
    }
}