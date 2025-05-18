using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using BrothelGame.Infrastructure.Providers;
using BrothelGame.Infrastructure.Services;
using BrothelGame.Infrastructure.States;
using BrothelGame.Windows.DialogueWindow;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private ArticyProvider articyProvider;

        public override void InstallBindings()
        {
            InstallInstallers();

            BindProviders();
            BindEntities();
        }

        private void InstallInstallers()
        {
            FactoryInstaller.Install(Container);
            ServiceInstaller.Install(Container);
            WindowInstaller.Install(Container);
        }

        private void BindProviders()
        {
            Container.Bind<ArticyProvider>().FromInstance(articyProvider).AsSingle();
        }

        private void BindEntities()
        {
            Container.Bind<IWindowViewKeeper>().To<WindowViewKeeper>().AsSingle();

            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<GameStateChanger>().AsSingle();
        }
    }
}