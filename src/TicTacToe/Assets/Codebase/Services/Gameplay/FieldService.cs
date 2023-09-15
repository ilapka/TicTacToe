using System;
using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class FieldService : IFieldService, IInitializable
    {
        private readonly IPersistentProgressService _gameProgressService;
        public Cell[][] Field { get; private set; }
        
        public event Action OnFieldUpdate;

        public FieldService(IPersistentProgressService progressService)
        {
            _gameProgressService = progressService;
        }
        
        public void Initialize()
        {
            CreateField();
        }

        private void CreateField()
        {
            GameConfiguration configuration = _gameProgressService.GameProgress.Configuration;

            Cell[][] field = new Cell[configuration.FieldWidth][];

            for (int x = 0; x < configuration.FieldWidth; x++)
            {
                field[x] = new Cell[configuration.FieldHeight];
                
                for (int y = 0; y < configuration.FieldHeight; y++)
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