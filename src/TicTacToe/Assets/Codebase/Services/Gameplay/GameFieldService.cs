using System;
using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class GameFieldService : IGameFieldService, IInitializable
    {
        private readonly IPersistentProgressService _gameProgressService;
        public Cell[][] Field { get; private set; }
        
        public event Action OnFieldUpdate;

        public GameFieldService(IPersistentProgressService progressService)
        {
            _gameProgressService = progressService;
        }
        
        public void Initialize()
        {
            CreateField();
        }

        private void CreateField()
        {
            FieldSettings settings = _gameProgressService.PlayerProgress.Settings;

            Cell[][] field = new Cell[settings.FieldWidth][];

            for (int x = 0; x < settings.FieldWidth; x++)
            {
                field[x] = new Cell[settings.FieldHeight];
                
                for (int y = 0; y < settings.FieldHeight; y++)
                {
                    Cell cell = new Cell(new Vector2Int(x, y));
                    field[x][y] = cell;
                }
            }

            Field = field;
            
            OnFieldUpdate?.Invoke();
        }
    }
}