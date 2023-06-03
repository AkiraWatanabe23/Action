using UnityEngine;

namespace StateMachine
{
    public class MoveBaseState : State
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Move State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Move State");
        }
    }
}
