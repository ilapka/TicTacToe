using System;
using UnityEngine;

namespace TicTacToe.Codebase.Data
{
    [Serializable]
    public class FieldSettings
    {
        [SerializeField]
        private int _fieldWidth = 3;
        [SerializeField]
        public int _fieldHeight = 3;
        [SerializeField]
        public int _chainLenght = 3;
        
        public int FieldWidth => _fieldWidth;
        public int FieldHeight => _fieldHeight;
        public int ChainLenght => _chainLenght;
    }
}