using UnityEngine;

namespace StateMachine
{
    public class DamageState : StateTransitionBase
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Damage State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Damage State");
        }
    }
}
