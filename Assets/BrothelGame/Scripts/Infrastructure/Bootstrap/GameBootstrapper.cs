using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            LoadGame();

            DontDestroyOnLoad(this);
        }

        private void LoadGame()
        {
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}