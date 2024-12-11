using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.GameFactory;
using TicTacToe.Codebase.Services.Gameplay;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.UI.Gameplay
{
    public class FieldView : MonoBehaviour
    {
        private IGameFieldService _gameFieldService;
        private IGameFactory _gameFactory;
        private GameSettings _gameSettings;

        [Inject]
        public void Construct(IGameFieldService gameFieldService, IGameFactory gameFactory, GameSettings gameSettings)
        {
            _gameFieldService = gameFieldService;
            _gameFactory = gameFactory;
            _gameSettings = gameSettings;
            
            _gameFieldService.OnFieldUpdate += UpdateView;
        }

        private void UpdateView()
        {
            foreach (Cell[] column in _gameFieldService.Field)
            {
                float cellOffset = _gameSettings.CellOffset; 
                
                foreach (Cell cell in column)
                {
                    Vector2 position = new Vector2(
                        cell.Position.x + cellOffset * cell.Position.x,
                        cell.Position.y + cellOffset * cell.Position.y);
                    
                    CellView cellView = _gameFactory.CreateCell(transform, position);
                    cellView.Setup(cell);
                }
            }
        }

        private void OnDestroy()
        {
            _gameFieldService.OnFieldUpdate -= UpdateView;
        }
    }
}