using System;
using System.Collections.Generic;
using BrothelGame.Infrastructure.States;

namespace BrothelGame.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> states;
        private IState currentState;

        public GameStateMachine(
            GameStateChanger gameStateChanger,
            BootstrapState.Factory bootstrapStateFactory,
            MainState.Factory mainStateFactory)
        {
            states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = bootstrapStateFactory.Create(this),
                [typeof(MainState)] = mainStateFactory.Create(this)
            };

            gameStateChanger.Initialize(this);
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            currentState?.Exit();

            TState state = GetState<TState>();
            currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return states[typeof(TState)] as TState;
        }
    }


}