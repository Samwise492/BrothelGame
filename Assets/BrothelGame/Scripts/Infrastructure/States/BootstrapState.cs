using BrothelGame.Infrastructure.Services;
using Zenject;

namespace BrothelGame.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly IStaticDataService staticDataService;

        public BootstrapState(GameStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            this.gameStateMachine = gameStateMachine;
            this.staticDataService = staticDataService;
        }

        public void Enter()
        {
            InitializeServices();
            EnterMainState();
        }

        public void Exit()
        {
        }

        private void InitializeServices()
        {
            staticDataService.LoadData();
        }

        private void EnterMainState()
        {
            gameStateMachine.Enter<MainState>();
        }

        public class Factory : PlaceholderFactory<GameStateMachine, BootstrapState> { }
    }
}