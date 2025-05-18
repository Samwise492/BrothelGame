using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.Services;
using BrothelGame.Windows.DialogueWindow;
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