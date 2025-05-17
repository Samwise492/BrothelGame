using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrothelGame.Infrastructure.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}