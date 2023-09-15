using System;
using UnityEngine;

namespace TicTacToe.Codebase.Services.InputService
{
    public interface IInputService
    {
        public event Action<RaycastHit> OnRaycastHit;
    }
}