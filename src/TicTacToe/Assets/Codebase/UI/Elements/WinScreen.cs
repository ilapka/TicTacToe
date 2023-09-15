using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.Services.UI;
using TMPro;
using UnityEngine;

namespace TicTacToe.Codebase.UI.Elements
{
    public class WinScreen : BaseWindow
    {
        [SerializeField]
        private TextMeshProUGUI _header;
        
        private WinScreenArgs _currentArgs;

        public override void SetArgs(UiArgs args)
        {
            _currentArgs = (WinScreenArgs)args;
        }

        public override void OpenSequence()
        {
            gameObject.SetActive(true);
            
            switch (_currentArgs.WinnerSign)
            {
                case SignType.Cross:
                    _header.text = "Cross wins";
                    break;
                
                case SignType.Ring:
                    _header.text = "Ring wins";
                    break;
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