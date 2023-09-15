using System;
using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.Services.UI;
using TMPro;
using UnityEngine;

namespace TicTacToe.Codebase.UI.Elements
{
    public class GameResultScreen : BaseWindow
    {
        [SerializeField]
        private TextMeshProUGUI _header;
        
        private GameResultScreenArgs _currentArgs;

        public override void SetArgs(UiArgs args)
        {
            _currentArgs = (GameResultScreenArgs)args;
        }

        public override void OpenSequence()
        {
            gameObject.SetActive(true);
            
            switch (_currentArgs.WinnerSign)
            {
                case SignType.Cross:
                    _header.text = "Victory of the crosses";
                    break;
                
                case SignType.Ring:
                    _header.text = "Victory of the rings";
                    break;
                
                case SignType.None:
                    _header.text = "Draw";
                    break;
                
                default: throw new Exception($"Can't handle sign type {_currentArgs.WinnerSign}");
            }
        }

        public override void CloseSequence()
        {
            _currentArgs?.OnCloseCallback?.Invoke();
            gameObject?.SetActive(true);
        }

        public void OnCloseButtonHandler()
        {
            CloseSequence();
        }
    }
}