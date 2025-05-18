using BrothelGame.Infrastructure.Data;

namespace BrothelGame.Infrastructure.Services
{
    public interface IWindowService
    {
        void Initialize();
        void Clear();
        bool IsWindowActive(WindowId windowId);
        void Open(WindowId id);
        void OpenWithArgs(WindowId id, object[] args);
        void Close(WindowId id);
    }
}