using System;
using System.Collections.Generic;
using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.PersistentProgress;
using TicTacToe.Codebase.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class GameFieldService : IGameFieldService, IInitializable, IProgressWriter, IDisposable
    {
        private readonly IPersistentProgressService _gameProgressService;
        private readonly ISaveLoadService _saveLoadService;
            
        public Cell[][] Field { get; private set; }
        
        public event Action OnFieldUpdate;

        public GameFieldService(IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameProgressService = progressService;
            _saveLoadService = saveLoadService;
            
            _saveLoadService.RegisterWriter(this);
        }
        
        public void Initialize()
        {
            CreateField();
        }

        private void CreateField()
        {
            FieldStatus fieldStatus = _gameProgressService.PlayerProgress.FieldStatus;
            FieldSettings settings = _gameProgressService.PlayerProgress.FieldSettings;
            
            bool isSaved = fieldStatus.Cells != null && fieldStatus.Cells.Length > 0;
            
            Cell[][] field = new Cell[settings.FieldWidth][];

            for (int x = 0; x < settings.FieldWidth; x++)
            {
                field[x] = new Cell[settings.FieldHeight];
                
                for (int y = 0; y < settings.FieldHeight; y++)
                {
                    Cell cell = isSaved
                        ? fieldStatus.Cells[settings.FieldWidth * y + x]
                        : new Cell(new Vector2Int(x, y));
                    
                    field[x][y] = cell;
                }
            }

            Field = field;

            OnFieldUpdate?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            List<Cell> cellList = new List<Cell>(Field.Length * Field[0].Length);

            foreach (var column in Field)
            {
                foreach (Cell cell in column)
                {
                    cellList.Add(cell);
                }
            }
            
            progress.FieldStatus.Cells = cellList.ToArray();
        }

        public void Dispose()
        {
            _saveLoadService.UnregisterWriter(this);
        }
    }
}