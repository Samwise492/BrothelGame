using BrothelGame.Infrastructure.Services;
using Zenject;

namespace BrothelGame.Infrastructure.States
{
    public class MainState : IState
    {
        private readonly IWindowService windowService;
        private readonly IDialogueService dialogueService;
        private readonly IStaticDataService staticDataService;

        public MainState(GameStateMachine gameStateMachine, // we'll need this GSM later on for sure. But for prototype it's redundant
            IWindowService windowService,
            IDialogueService dialogueService,
            IStaticDataService staticDataService)
        {
            this.windowService = windowService;
            this.dialogueService = dialogueService;
            this.staticDataService = staticDataService;
        }

        public void Enter()
        {
            // By design, there should be Main scene loading after bootstrap, and when it's loaded, we do next:
            windowService.Initialize();

            // Some trigger should be, but for prototype we manually trigger it
            dialogueService.StartDialogueSequence(0, staticDataService.DialogueData.Length - 1);
        }

        public void Exit()
        {
            windowService.Clear();
        }

        public class Factory : PlaceholderFactory<GameStateMachine, MainState> { }
    }
}