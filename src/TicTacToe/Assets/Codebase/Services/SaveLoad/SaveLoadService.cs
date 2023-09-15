using System;
using System.Collections.Generic;
using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Infrastructure;
using TicTacToe.Codebase.Services.PersistentProgress;
using UnityEngine;

namespace TicTacToe.Codebase.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService, IDisposable
    {
        private const string PlayerProgressKey = "PlayerProgress";

        private readonly IPersistentProgressService _progressService;
        private readonly ApplicationQuitDetector _quitDetector;

        private readonly HashSet<IProgressWriter> _progressWriters = new HashSet<IProgressWriter>();

        public SaveLoadService(IPersistentProgressService progressService, ApplicationQuitDetector quitDetector)
        {
            _progressService = progressService;
            _quitDetector = quitDetector;

            //_quitDetector.OnApplicationPaused += SaveProgress;
            _quitDetector.OnApplicationQuited += SaveProgress;
        }

        public void SaveProgress()
        {
            foreach (IProgressWriter progressWriter in _progressWriters)
            {
                progressWriter.UpdateProgress(_progressService.PlayerProgress);
            }

            PlayerPrefs.SetString(PlayerProgressKey, _progressService.PlayerProgress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            PlayerProgress progress = PlayerPrefs.GetString(PlayerProgressKey)?.ToDeserialized<PlayerProgress>();
            return progress;
        }

        public void RegisterWriter(IProgressWriter progressWriter)
        {
            _progressWriters.Add(progressWriter);
        }

        public void UnregisterWriter(IProgressWriter progressWriter)
        {
            _progressWriters.Remove(progressWriter);
        }

        public void Dispose()
        {
            //_quitDetector.OnApplicationPaused -= SaveProgress;
            _quitDetector.OnApplicationQuited -= SaveProgress;
        }
    }
}