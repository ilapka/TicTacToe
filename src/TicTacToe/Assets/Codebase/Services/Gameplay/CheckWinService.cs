using System;
using TicTacToe.Codebase.Services.PersistentProgress;
using UnityEngine;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class CheckWinService : ICheckWinService, IDisposable
    {
        private readonly CellClickHandler _clickHandler;
        private readonly IGameFieldService _gameFieldService;
        private readonly IPersistentProgressService _progressService;

        public event Action<SignType> OnWin;

        public CheckWinService(CellClickHandler clickHandler, IGameFieldService gameFieldService, IPersistentProgressService progressService)
        {
            _clickHandler = clickHandler;
            _gameFieldService = gameFieldService;
            _progressService = progressService;
            
            _clickHandler.OnCellClicked += CheckWin;
        }

        private void CheckWin(Cell clickedCell)
        {
            var chainLength = GetLongestChain(_gameFieldService.Field, clickedCell);
            
            if (chainLength >= _progressService.PlayerProgress.FieldSettings._chainLenght)
            {
                DeclareWin(clickedCell.Sign);
            }
        }

        private void DeclareWin(SignType signType)
        {
            OnWin?.Invoke(signType);
        }

        private int GetLongestChain(Cell[][] cells, Cell startCell)
        {
            SignType startType = startCell.Sign;

            if (startType == SignType.None)
                return 0;

            Vector2Int down = new Vector2Int(-1, 0);
            Vector2Int up = new Vector2Int(1, 0);

            int verticalLenght = 1 + GetLongestChainOnDirection(cells, startCell, down)
                                 + GetLongestChainOnDirection(cells, startCell, up);
            
            Vector2Int right = new Vector2Int(0, 1);
            Vector2Int left = new Vector2Int(0, -1);
            
            int horizontalLenght = 1 + GetLongestChainOnDirection(cells, startCell, right)
                + GetLongestChainOnDirection(cells, startCell, left);
            
            Vector2Int diagonalOneRight = new Vector2Int(1,-1);
            Vector2Int diagonalOneLeft = new Vector2Int(-1, 1);
            
            int diagonalOneLenght = 1 + GetLongestChainOnDirection(cells, startCell, diagonalOneRight)
                                    + GetLongestChainOnDirection(cells, startCell, diagonalOneLeft);
            
            Vector2Int diagonalTwoRight = new Vector2Int(1, 1);
            Vector2Int diagonalTwoLeft = new Vector2Int(-1, -1);

            int diagonalTwoLenght = 1 + GetLongestChainOnDirection(cells, startCell, diagonalTwoRight)
                                    + GetLongestChainOnDirection(cells, startCell, diagonalTwoLeft);
            
            return Mathf.Max(verticalLenght, horizontalLenght, diagonalOneLenght, diagonalTwoLenght);
        }

        private int GetLongestChainOnDirection(Cell[][] cells, Cell startCell, Vector2Int direction)
        {
            Vector2Int currentPosition = startCell.Position + direction;

            int currentLength = 0;
            
            while (IsValidPosition(cells, currentPosition))
            {
                Cell cell = cells[currentPosition.x][currentPosition.y];
                
                if (cell.Sign != startCell.Sign)
                {
                    break;
                }
                
                currentLength++;
                currentPosition += direction;
            }

            return currentLength;
        }

        private bool IsValidPosition(Cell[][] cells, Vector2Int position)
        {
            return cells.Length > position.x
                   && position.x >= 0
                   && cells[position.x].Length > position.y
                   && position.y >= 0;
        }

        public void Dispose()
        {
            _clickHandler.OnCellClicked -= CheckWin;
        }
    }
}