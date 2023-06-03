using UnityEngine;

namespace StateMachine
{
    public class EscapeState : SubState
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Escape State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Escape State");
        }
    }
}
