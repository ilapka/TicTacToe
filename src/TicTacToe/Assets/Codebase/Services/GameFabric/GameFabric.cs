using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.Services.ResourceService;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Services.GameFabric
{
    public class GameFabric : IGameFabric
    {
        private readonly IResources _resources;
        private readonly DiContainer _diContainer;

        public GameFabric(IResources resources, DiContainer diContainer)
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