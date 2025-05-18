using BrothelGame.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.Installers
{
    public class ServiceInstaller : Installer<ServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IDialogueService>().To<DialogueService>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
        }
    }
}