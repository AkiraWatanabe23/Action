using UnityEngine;

namespace StateMachine
{
    public class DeathState : SubState
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Death State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Death State");
        }
    }
}
