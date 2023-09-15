using System;
using System.Collections.Generic;
using TicTacToe.Codebase.UI.Elements;

namespace TicTacToe.Codebase.Services.UI
{
    public class UiService : IUiService
    {
        private readonly Dictionary<Type, BaseWindow> _windows = new Dictionary<Type, BaseWindow>();
        private LoadingCurtain _loadingCurtain;
        
        private BaseWindow _currentWindow;
        
        public UiService()
        {
            
        }

        public void RegisterUi(UiContainer container) => AddContent(container);
        public void UnregisterUi(UiContainer container) => RemoveContent(container);

        public void OpenWindow<T>(UiArgs args = null) where T : BaseWindow
        {
            CloseCurrentWindow();
            _currentWindow = _windows[typeof(T)];
            _currentWindow.SetArgs(args);
            _currentWindow.OpenSequence();
        }
        
        public void CloseCurrentWindow()
        {
            if (_currentWindow != null)
            {
                _currentWindow.CloseSequence();
                _currentWindow = null;
            }
        }

        public void FadeIn()
        {
            _loadingCurtain.Show();
        }

        public void FadeOut()
        {
            _loadingCurtain.Hide();
        }

        private void AddContent(UiContainer container)
        {
            foreach (BaseWindow window in container.Windows)
                _windows.Add(window.GetType(), window);

            if (container is ApplicationUiContainer appContainer)
            {
                _loadingCurtain = appContainer.LoadingCurtain;
            }
        }

        private void RemoveContent(UiContainer container)
        {
            foreach (BaseWindow window in container.Windows)
                _windows.Remove(window.GetType());
        }
    }
}