using System;
using TicTacToe.Codebase.Services.InputService;
using UnityEngine;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class CellClickHandler : IDisposable
    {
        private readonly IInputService _input;
        private readonly IGameState _gameState;

        public event Action<Cell> OnCellClicked;

        public CellClickHandler(IGameState gameState, IInputService input)
        {
            _input = input;
            _gameState = gameState;
            
            _input.OnRaycastHit += OnClicked;
        }

        private void OnClicked(RaycastHit hitInfo)
        {
            CellView cellView = hitInfo.collider.GetComponent<CellView>();
            
            if (cellView &&
                cellView.MyCell.Sign == SignType.None)
            {
                cellView.MyCell.Sign = _gameState.CurrentSign;
                cellView.UpdateView();
                _gameState.SwitchTurn();
                
                OnCellClicked?.Invoke(cellView.MyCell);
            }
        }

        public void Dispose()
        {
            _input.OnRaycastHit -= OnClicked;
        }
    }
}