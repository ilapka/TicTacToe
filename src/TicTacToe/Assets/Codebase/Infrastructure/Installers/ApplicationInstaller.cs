using TicTacToe.Codebase.Infrastructure.StateMachine;
using TicTacToe.Codebase.Services.GameFabric;
using TicTacToe.Codebase.Services.InputService;
using TicTacToe.Codebase.Services.PersistentProgress;
using TicTacToe.Codebase.Services.ResourceService;
using TicTacToe.Codebase.Services.SaveLoad;
using TicTacToe.Codebase.Services.UI;
using Zenject;

namespace TicTacToe.Codebase.Infrastructure.Installers
{
    public class ApplicationInstaller : MonoInstaller, ICoroutineRunner
    {
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
        }

        private void BindServices()
        {
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IUiService>().To<UiService>().AsSingle();
            Container.Bind<IResources>().To<ResourceService>().AsSingle();
            Container.Bind<IGameFabric>().To<GameFabric>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }
    }
}
