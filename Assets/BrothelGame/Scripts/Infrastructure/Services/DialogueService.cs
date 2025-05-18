using Articy.Unity;
using BrothelGame.Infrastructure.Data;
using BrothelGame.Windows.DialogueWindow;

namespace BrothelGame.Infrastructure.Services
{
    public class DialogueService : IDialogueService
    {
        private readonly IWindowService windowService;
        private readonly DialogueWindow dialogueWindow;
        private readonly IStaticDataService staticDataService;

        private int currentDialogueIndex = 0;

        public DialogueService(IWindowService windowService, DialogueWindow dialogueWindow, IStaticDataService staticDataService)
        {
            this.windowService = windowService;
            this.dialogueWindow = dialogueWindow;
            this.staticDataService = staticDataService;
        }

        public void StartDialogueSequence(int indexFrom, int indexTo)
        {
            dialogueWindow.OnDialogueGoing -= SetNextInSequenceDialogue;
            dialogueWindow.OnDialogueGoing += SetNextInSequenceDialogue;

            StartDialogue(staticDataService.DialogueData[currentDialogueIndex++].Id);
        }

        public void StartDialogue(DialogueId dialogueId)
        {
            windowService.Open(WindowId.Dialogue);

            ArticyObject dialogue = staticDataService.GetDialogueData(dialogueId).Reference.GetObject();
            dialogueWindow.StartDialogue(dialogue);
        }

        private void SetNextInSequenceDialogue(bool isDialogueEnded)
        {
            if (isDialogueEnded && currentDialogueIndex < staticDataService.DialogueData.Length)
            {
                StartDialogue(staticDataService.DialogueData[currentDialogueIndex++].Id);
            }
        }
    }
}