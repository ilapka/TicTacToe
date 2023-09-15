using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.PersistentProgress;
using UnityEngine;

namespace TicTacToe.Codebase.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string GameProgressKey = "GameProgress";

        private readonly IPersistentProgressService _progressService;
        //private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService) //IGameFactory gameFactory)
        {
            _progressService = progressService;
            //_gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            // foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
            // {
            //     progressWriter.UpdateProgress(_progressService.Progress);
            // }
            //
            // PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(GameProgressKey)?.ToDeserialized<PlayerProgress>();
        }
    }
}