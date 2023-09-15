using System;
using TicTacToe.Codebase.Infrastructure;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.InputService
{
    public class InputService : ITickable, IInputService
    {
        private readonly ICameraProvider _cameraProvider;
        
        public event Action<RaycastHit> OnRaycastHit;

        public InputService(ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Camera camera = _cameraProvider.GetCamera();
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    OnRaycastHit?.Invoke(hitInfo);
                }
            }
        }
    }
}