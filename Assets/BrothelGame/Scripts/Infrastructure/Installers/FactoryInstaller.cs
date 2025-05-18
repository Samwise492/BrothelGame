using BrothelGame.Infrastructure.Core;
using BrothelGame.Infrastructure.Services;
using BrothelGame.Infrastructure.States;
using Zenject;

namespace BrothelGame.Infrastructure.Installers
{
    public class FactoryInstaller : Installer<FactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<GameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<GameStateMachine, MainState, MainState.Factory>();

            Container.Bind<IViewFactory>().To<ViewFactory>().AsSingle();
            Container.Bind<IPrefabFactory>().To<PrefabFactory>().AsSingle();
            Container.Bind<IWindowViewFactory>().To<WindowViewFactory>().AsSingle();
        }
    }
}
