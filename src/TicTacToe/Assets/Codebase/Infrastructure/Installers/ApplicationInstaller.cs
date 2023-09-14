using TicTacToe.Codebase.Infrastructure.StateMachine;
using Zenject;

namespace TicTacToe.Codebase.Infrastructure.Installers
{
    public class ApplicationInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.Bind<DIFactory>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<ApplicationBootstrapper>().AsSingle();
            Container.Bind<IApplicationStateMachine>().To<ApplicationStateMachine>().AsSingle();
        }
    }
}
