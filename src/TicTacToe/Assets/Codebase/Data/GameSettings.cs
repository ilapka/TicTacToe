using UnityEngine;

namespace TicTacToe.Codebase.Data
{
    [CreateAssetMenu(menuName = "TicTac/Create GameSettings", fileName = "GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public float CellOffset;
        public FieldSettings DefaultFieldSettigns;
    }
}