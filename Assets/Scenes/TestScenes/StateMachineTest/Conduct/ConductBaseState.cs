using UnityEngine;

namespace StateMachine
{
    public class ConductBaseState : State
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Conduct State");

            //ここで子ステートへの遷移
            switch (owner.NextSubState)
            {
                case StateMachineRoot.SubState.Attack:
                    owner.ChangeSubState(StateMachineRoot.SubState.Attack);
                    break;
                case StateMachineRoot.SubState.Damage:
                    owner.ChangeSubState(StateMachineRoot.SubState.Damage);
                    break;
                case StateMachineRoot.SubState.Death:
                    owner.ChangeSubState(StateMachineRoot.SubState.Death);
                    break;
            }
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Conduct State");
        }
    }
}
