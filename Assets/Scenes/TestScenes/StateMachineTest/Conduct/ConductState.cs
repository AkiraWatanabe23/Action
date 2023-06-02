using UnityEngine;

namespace StateMachine
{
    public class ConductState : StateTransitionBase
    {
        private ConductChildState _conductChild = ConductChildState.Attack;

        public ConductChildState ConductChild => _conductChild;

        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Conduct State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Conduct State");
        }

        public enum ConductChildState
        {
            Attack,
            Damage,
            Death
        }
    }
}
