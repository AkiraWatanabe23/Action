using UnityEngine;

namespace StateMachine
{
    public class RunAwayState : SubState
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter RunAway State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit RunAway State");
        }
    }
}
