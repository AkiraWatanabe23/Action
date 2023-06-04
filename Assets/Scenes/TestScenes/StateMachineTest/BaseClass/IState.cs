using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public interface IState
    {
        public void OnEnter(StateMachineRoot owner);
        public void OnUpdate(StateMachineRoot owner);
        public void OnExit(StateMachineRoot owner);
    }
}
