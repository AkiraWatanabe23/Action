using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    public class DeathState : ConductBaseState, IState
    {
        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Death State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            if (Anim)
            {

            }
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Death State");
        }
    }
}
