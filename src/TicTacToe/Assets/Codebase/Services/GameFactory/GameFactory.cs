using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.Services.ResourceService;
using TicTacToe.Codebase.UI.Gameplay;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IResources _resources;
        private readonly DiContainer _diContainer;

        public GameFactory(IResources resources, DiContainer diContainer)
        {
            _resources = resources;
            _diContainer = diContainer;
        }

        public CellView CreateCell(Transform root, Vector2 position)
        {
            CellView prefab = _resources.LoadCell();
            return Instantiate(prefab, root, position);
        }

        private T Instantiate<T>(T prefab, Transform root, Vector2 position) where T : MonoBehaviour
        {
            return _diContainer.InstantiatePrefabForComponent<T>(prefab.gameObject, position, Quaternion.identity, root);
        }
    }
}