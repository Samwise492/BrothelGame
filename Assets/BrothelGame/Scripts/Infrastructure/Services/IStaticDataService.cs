using BrothelGame.Infrastructure.Data;

namespace BrothelGame.Infrastructure.Services
{
    public interface IStaticDataService
    {
        void LoadData();
        WindowData GetWindowData(WindowId windowId);
        DialogueData GetDialogueData(DialogueId dialogueId);
        DialogueData[] DialogueData { get; }
    }
}
