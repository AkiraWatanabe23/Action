using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    public class EscapeState : MoveBaseState, IState
    {
        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Escape State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Escape State");
        }
    }
}
