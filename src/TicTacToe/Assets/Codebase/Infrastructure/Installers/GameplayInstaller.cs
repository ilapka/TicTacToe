using TicTacToe.Codebase.Services.Gameplay;
using Zenject;

namespace TicTacToe.Codebase.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FieldService>().AsSingle();
        }
    }
}