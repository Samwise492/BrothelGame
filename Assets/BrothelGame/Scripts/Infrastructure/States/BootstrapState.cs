using System.Collections;
using System.Collections.Generic;
using Articy.Articybrothel;
using Articy.Unity;
using BrothelGame.Windows.DialogueWindow;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.States
{
    public class BootstrapState : IState
    {
        public BootstrapState()
        {
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public class Factory : PlaceholderFactory<GameStateMachine, BootstrapState> { }
    }
}