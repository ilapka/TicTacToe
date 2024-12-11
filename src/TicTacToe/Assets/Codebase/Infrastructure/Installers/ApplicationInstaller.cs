using TicTacToe.Codebase.Infrastructure.StateMachine;
using TicTacToe.Codebase.Services.GameFactory;
using TicTacToe.Codebase.Services.InputService;
using TicTacToe.Codebase.Services.PersistentProgress;
using TicTacToe.Codebase.Services.ResourceService;
using TicTacToe.Codebase.Services.SaveLoad;
using TicTacToe.Codebase.Services.UI;
using UnityEngine;
using Zenject;

namespace TicTacToe.Codebase.Infrastructure.Installers
{
    public class ApplicationInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField]
        private ApplicationQuitDetector _quitDetector;
        
        public override void InstallBindings()
        {
            BindInfrastructure();
            BindServices();
        }

        private void BindInfrastructure()
        {
            Container.Bind<DIFactory>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<ApplicationBootstrapper>().AsSingle();
            Container.Bind<IApplicationStateMachine>().To<ApplicationStateMachine>().AsSingle();
            Container.Bind<IRestartLevelService>().To<RestartLevelService>().AsSingle();
            Container.BindInstance(_quitDetector).AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.BindInterfacesTo<SaveLoadService>().AsSingle();
            Container.Bind<IUiService>().To<UiService>().AsSingle();
            Container.Bind<IResources>().To<ResourceService>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }
    }
}
