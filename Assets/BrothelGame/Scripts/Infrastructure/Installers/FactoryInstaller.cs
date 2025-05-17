using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.Installers
{
    public class FactoryInstaller : Installer<FactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<GameStateMachine, BootstrapState, BootstrapState.Factory>();
        }
    }
}
