namespace TicTacToe.Codebase.Services.UI
{
    public interface IUiService
    {
        void RegisterUi(UiContainer container);
        void UnregisterUi(UiContainer container);
        void OpenWindow<T>(UiArgs args = null) where T : BaseWindow;
        void CloseCurrentWindow();
        void FadeIn();
        void FadeOut();
    }
}