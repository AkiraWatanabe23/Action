using UnityEngine;

namespace StateMachine
{
    public class ChaseState : MoveBaseState, IState
    {
        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Chase State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Chase State");
        }
    }
}
