using TicTacToe.Codebase.Data;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Infrastructure.Installers
{
    [CreateAssetMenu(menuName = "TicTac/Create GameSettingsInstaller", fileName = "GameSettingsInstaller", order = 0)]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField]
        private GameSettings _settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_settings).IfNotBound();
        }
    }
}