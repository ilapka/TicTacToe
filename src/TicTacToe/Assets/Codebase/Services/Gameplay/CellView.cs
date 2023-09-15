using UnityEngine;

namespace TicTacToe.Codebase.Services.Gameplay
{
    public class CellView : MonoBehaviour
    {
        public Cell MyCell { get; private set; }

        public void Setup(Cell cell)
        {
            MyCell = cell;
        }
    }
}