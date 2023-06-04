using UnityEngine;

namespace StateMachine
{
    public class SearchState : MoveBaseState, IState
    {
        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Search State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Search State");
        }
    }
}
