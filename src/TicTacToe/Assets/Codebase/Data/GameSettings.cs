using UnityEngine;

namespace TicTacToe.Codebase.Data
{
    [CreateAssetMenu(menuName = "TicTac/Create GameSettings", fileName = "GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        private float _cellOffset;
        [SerializeField]
        private FieldSettings _defaultFieldSettigns;
        
        public float CellOffset => _cellOffset;
        public FieldSettings DefaultFieldSettigns => _defaultFieldSettigns;
    }
}