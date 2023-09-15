using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.UI
{
    public abstract class BaseUiElement : MonoBehaviour
    {
        protected IUiService UiService { get; private set; }

        [Inject]
        public void Construct(IUiService uiService)
        {
            UiService = uiService;
        }

        public abstract void SetArgs(UiArgs args);

        public abstract void OpenSequence();

        public abstract void CloseSequence();
    }
}