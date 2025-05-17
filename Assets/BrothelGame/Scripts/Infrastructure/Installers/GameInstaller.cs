using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallInstallers();
        }

        private void InstallInstallers()
        {
            FactoryInstaller.Install(Container);
            WindowInstaller.Install(Container);
        }
    }
}