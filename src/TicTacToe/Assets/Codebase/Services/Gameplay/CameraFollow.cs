using System;
using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Infrastructure;
using TicTacToe.Codebase.Services.PersistentProgress;
using UnityEngine;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class CameraFollow : IDisposable
    {
        private readonly IGameFieldService _gameField;
        private readonly ICameraProvider _cameraProvider;
        private readonly IPersistentProgressService _persistentProgress;
        private readonly GameSettings _gameSettings;

        public CameraFollow(IGameFieldService gameField, ICameraProvider cameraProvider, IPersistentProgressService persistentProgress, GameSettings gameSettings)
        {
            _gameField = gameField;
            _cameraProvider = cameraProvider;
            _persistentProgress = persistentProgress;
            _gameSettings = gameSettings;
            
            _gameField.OnFieldUpdate += UpdateCamera;
        }

        private void UpdateCamera()
        {
            FieldSettings fieldSettings = _persistentProgress.PlayerProgress.FieldSettings;
            
            Camera camera = _cameraProvider.GetCamera();
            camera.orthographic = true;
            camera.orthographicSize = fieldSettings._fieldHeight / 2f +
                                      (fieldSettings._fieldHeight - 1) * _gameSettings.CellOffset / 2f;

            camera.transform.position = new Vector3(fieldSettings.FieldWidth / 2f + (fieldSettings.FieldWidth - 1) * _gameSettings.CellOffset / 2f,
                fieldSettings._fieldHeight / 2f + (fieldSettings._fieldHeight - 1) * _gameSettings.CellOffset / 2f);
        }

        public void Dispose()
        {
            _gameField.OnFieldUpdate -= UpdateCamera;
        }
    }
}