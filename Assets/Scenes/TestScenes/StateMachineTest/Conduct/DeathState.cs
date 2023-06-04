using UnityEngine;

namespace StateMachine
{
    public class DeathState : ConductBaseState, IState
    {
        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Death State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Death State");
        }
    }
}
