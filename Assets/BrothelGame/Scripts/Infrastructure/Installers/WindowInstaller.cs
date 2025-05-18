using System.Collections;
using System.Collections.Generic;
using BrothelGame.Windows.DialogueWindow;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.Installers
{
    public class WindowInstaller : Installer<WindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<DialogueWindow>().AsSingle();
        }
    }
}