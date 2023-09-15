using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.UI
{ 
    public class UiContainer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _windowsRoot;

        private IUiService _uiService;

        public List<BaseWindow> Windows { get; private set; }

        [Inject]
        public void Construct(IUiService uiService)
        {
            _uiService = uiService;
            Init();
        }

        private void Init()
        {
            Windows = _windowsRoot.GetComponentsInChildren<BaseWindow>(true).ToList();
            _uiService.RegisterUi(this);
        }

        private void OnDestroy()
        {
            _uiService.UnregisterUi(this);
        }
    }
}