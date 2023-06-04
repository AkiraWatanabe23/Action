using UnityEngine;

namespace StateMachine
{
    public class AttackState : ConductBaseState, IState
    {
        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Attack State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Attack State");
        }
    }
}
