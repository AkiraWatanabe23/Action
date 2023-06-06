using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    public class DamageState : ConductBaseState, IState
    {
        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Damage State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            if (Anim)
            {

            }
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Damage State");
        }
    }
}
