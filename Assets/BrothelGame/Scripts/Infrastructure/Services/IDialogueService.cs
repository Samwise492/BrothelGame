using BrothelGame.Infrastructure.Data;

namespace BrothelGame.Infrastructure.Services
{
    public interface IDialogueService
    {
        void StartDialogue(DialogueId dialogueId);
        void StartDialogueSequence(int indexFrom, int indexTo);
    }
}