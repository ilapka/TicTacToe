using UnityEngine;

namespace TicTacToe.Codebase.Infrastructure
{
    public class CameraProvider : ICameraProvider
    {
        private Camera _currentCamera;
        
        public Camera GetCamera()
        {
            if (_currentCamera == null || !_currentCamera.gameObject.activeInHierarchy)
            {
                _currentCamera = Camera.main;
            }

            return _currentCamera;
        }
    }
}