using TicTacToe.Codebase.Services.GameFabric;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField]
        private float _cellOffset;
        
        private IFieldService _fieldService;
        private IGameFabric _gameFabric;

        [Inject]
        public void Construct(IFieldService fieldService, IGameFabric gameFabric)
        {
            _fieldService = fieldService;
            _gameFabric = gameFabric;
            
            _fieldService.OnFieldUpdate += UpdateView;
        }

        private void UpdateView()
        {
            foreach (Cell[] column in _fieldService.Field)
            {
                foreach (Cell cell in column)
                {
                    Vector2 position = new Vector2(
                        cell.Position.x + _cellOffset * cell.Position.x,
                        cell.Position.y + _cellOffset * cell.Position.y);
                    
                    CellView cellView = _gameFabric.CreateCell(transform, position);
                    cellView.Setup(cell);
                }
            }
        }

        private void OnDestroy()
        {
            _fieldService.OnFieldUpdate -= UpdateView;
        }
    }
}