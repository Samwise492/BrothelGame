using BrothelGame.Infrastructure.Core;
using BrothelGame.Infrastructure.Data;
using BrothelGame.Windows.DialogueWindow;

namespace BrothelGame.Infrastructure.Services
{
    public class WindowViewFactory : IWindowViewFactory
    {
        private readonly IViewFactory _viewFactory;
        private readonly IWindowViewKeeper _windowsViewKeeper;

        public WindowViewFactory(IViewFactory viewFactory, IWindowViewKeeper windowsViewKeeper)
        {
            _viewFactory = viewFactory;
            _windowsViewKeeper = windowsViewKeeper;
        }

        public DialogueWindowView CreateDialogueWindow()
        {
            DialogueWindowView view = _viewFactory.CreateView<DialogueWindowView, DialogueWindowHierarchy>(WindowId.Dialogue);
            _windowsViewKeeper.Views.Add(WindowId.Dialogue, view);
            return view;
        }
    }
}