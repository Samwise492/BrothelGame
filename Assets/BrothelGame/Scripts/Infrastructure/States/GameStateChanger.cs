namespace BrothelGame.Infrastructure.States
{
    public class GameStateChanger
    {
        private GameStateMachine _gameStateMachine;

        public void Initialize(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter<TState>() where TState : class, IState
        {
            _gameStateMachine.Enter<TState>();
        }
    }
}