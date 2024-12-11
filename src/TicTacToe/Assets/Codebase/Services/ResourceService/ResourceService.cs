using System.Collections.Generic;
using TicTacToe.Codebase.Services.Gameplay;
using TicTacToe.Codebase.UI.Gameplay;
using UnityEngine;

namespace TicTacToe.Codebase.Services.ResourceService
{
    public class ResourceService : IResources
    {
        private const string CellPrefabPath = "Gameplay/CellView";
        
        private readonly Dictionary<string, GameObject> _cash = new Dictionary<string, GameObject>();

        public CellView LoadCell()
        {
            return Load<CellView>(CellPrefabPath);
        }

        private T Load<T>(string path) where T : MonoBehaviour
        {
            if (_cash.ContainsKey(path))
            {
                return _cash[path].GetComponent<T>();
            }

            T prefab = Resources.Load<T>(path);

            if (prefab != null)
            {
                _cash.Add(path, prefab.gameObject);
                return prefab;    
            }

            Debug.LogError($"Can't load {typeof(T)} by path {path}");
            return null;
        }
    }
}