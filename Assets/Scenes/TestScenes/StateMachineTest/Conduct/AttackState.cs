using UnityEngine;

namespace StateMachine
{
    public class AttackState : State
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Attack State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Attack State");
        }
    }
}
