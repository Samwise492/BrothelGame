using BrothelGame.Windows.DialogueWindow;

namespace BrothelGame.Infrastructure.Services
{
    public interface IWindowViewFactory
    {
        public DialogueWindowView CreateDialogueWindow();
    }
}