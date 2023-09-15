using System;
using TicTacToe.Codebase.Infrastructure;
using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.Services.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.UI.Elements
{
    public class HudScreen : BaseWindow
    {
        [SerializeField]
        private TextMeshProUGUI _header;

        private IGameState _gameState;
        private SignType _currentTurn;
        private IRestartLevelService _restartLevelService;

        [Inject]
        public void Construct(IGameState gameState, IRestartLevelService restartLevelService)
        {
            _gameState = gameState;
            _restartLevelService = restartLevelService;
            
            _gameState.OnSignSwitched += SetTurn;
        }

        public override void OpenSequence()
        {
            gameObject.SetActive(true);
            SetTurn(_gameState.CurrentSign);
        }

        private void SetTurn(SignType currentTurn)
        {
            _currentTurn = currentTurn;
            
            switch (_currentTurn)
            {
                case SignType.Cross:
                    _header.text = "Turn of cross";
                    break;
                
                case SignType.Ring:
                    _header.text = "Turn of rings";
                    break;
                
                case SignType.None:
                    _header.text = "Draw";
                    break;
                
                default: throw new Exception($"Can't handle sign type {_currentTurn}");
            }
        }

        public void OnRestartButtonHandler()
        {
            _restartLevelService.Restart();
        }

        public override void SetArgs(UiArgs args) { }

        public override void CloseSequence()
        {
            gameObject?.SetActive(true);
        }

        private void OnDestroy()
        {
            _gameState.OnSignSwitched -= SetTurn;
        }
    }
}