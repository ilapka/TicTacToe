using TicTacToe.Codebase.UI.Elements;
using UnityEngine;

namespace TicTacToe.Codebase.Services.UI
{
    public class ApplicationUiContainer : UiContainer
    {
        [SerializeField]
        private LoadingCurtain _loadingCurtain;
        public LoadingCurtain LoadingCurtain => _loadingCurtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}