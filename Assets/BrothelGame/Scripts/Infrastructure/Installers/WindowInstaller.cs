using BrothelGame.Windows.DialogueWindow;
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