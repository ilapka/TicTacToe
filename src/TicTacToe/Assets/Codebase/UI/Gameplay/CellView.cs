using TicTacToe.Codebase.Services.Gameplay;
using UnityEngine;

namespace TicTacToe.Codebase.UI.Gameplay
{
    public class CellView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _crossView;
        [SerializeField]
        private GameObject _ringView;

        public Cell MyCell { get; private set; }

        public void Setup(Cell cell)
        {
            MyCell = cell;
            UpdateView();
        }

        public void UpdateView()
        {
            switch (MyCell.Sign)
            {
                case SignType.None:
                    _crossView.SetActive(false);
                    _ringView.SetActive(false);
                    break;
                
                case SignType.Cross:
                    _crossView.SetActive(true);
                    _ringView.SetActive(false);
                    break;
                
                case SignType.Ring:
                    _crossView.SetActive(false);
                    _ringView.SetActive(true);
                    break;
            }
        }
    }
}