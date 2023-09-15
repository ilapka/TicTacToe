using TicTacToe.Codebase.Services.Gameplay;
using Zenject;

namespace TicTacToe.Codebase.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameFieldService>().AsSingle();
            Container.BindInterfacesTo<CameraFollow>().AsSingle();
            Container.BindInterfacesTo<GameState>().AsSingle();
            Container.BindInterfacesAndSelfTo<CellClickHandler>().AsSingle();
            Container.BindInterfacesTo<CheckWinService>().AsSingle();
            Container.BindInterfacesTo<EndGameService>().AsSingle();
            Container.BindInterfacesTo<CheckCheckDrawService>().AsSingle();
        }
    }
}