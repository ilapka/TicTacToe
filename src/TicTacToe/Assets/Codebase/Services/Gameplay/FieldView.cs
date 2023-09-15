using TicTacToe.Codebase.Data;
using TicTacToe.Codebase.Services.GameFabric;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class FieldView : MonoBehaviour
    {
        private IGameFieldService _gameFieldService;
        private IGameFabric _gameFabric;
        private GameSettings _gameSettings;

        [Inject]
        public void Construct(IGameFieldService gameFieldService, IGameFabric gameFabric, GameSettings gameSettings)
        {
            _gameFieldService = gameFieldService;
            _gameFabric = gameFabric;
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
                    
                    CellView cellView = _gameFabric.CreateCell(transform, position);
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