using System;
using TicTacToe.Codebase.Infrastructure;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class CheckCheckDrawService : ICheckDrawService, IDisposable
    {
        private readonly CellClickHandler _clickHandler;
        private readonly IGameFieldService _gameFieldService;
        private readonly IRestartLevelService _restartService;

        private int _currentClickedCount;
        private int _maxCellsCount;

        public event Action OnDraw;

        public CheckCheckDrawService(CellClickHandler clickHandler, IGameFieldService gameFieldService)
        {
            _clickHandler = clickHandler;
            _gameFieldService = gameFieldService;

            _gameFieldService.OnFieldUpdate += UpdateMaxCellsCount;
            _clickHandler.OnCellClicked += CheckDraw;
        }

        private void UpdateMaxCellsCount()
        {
            _maxCellsCount = _gameFieldService.Field.Length * _gameFieldService.Field[0].Length;
        }

        private void CheckDraw(Cell cell)
        {
            _currentClickedCount++;

            if (_currentClickedCount >= _maxCellsCount)
            {
                DeclareDraw();
            }
        }

        private void DeclareDraw()
        {
            OnDraw?.Invoke();
        }

        public void Dispose()
        {
            _gameFieldService.OnFieldUpdate -= UpdateMaxCellsCount;
            _clickHandler.OnCellClicked -= CheckDraw;
        }
    }
}