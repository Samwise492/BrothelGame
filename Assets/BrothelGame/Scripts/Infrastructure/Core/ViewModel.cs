namespace BrothelGame.Infrastructure.Core
{
    public abstract class ViewModel<TModel> : DisposableCollector, IViewModel
    {
        protected TModel Model { get; }

        protected ViewModel(TModel model)
        {
            Model = model;
        }
    }
}