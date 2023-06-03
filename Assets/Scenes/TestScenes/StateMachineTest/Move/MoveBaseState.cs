using UnityEngine;

namespace StateMachine
{
    public class MoveBaseState : State
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Move State");

            //ここで子ステートへの遷移
            switch (owner.NextSubState)
            {
                case StateMachineRoot.SubState.Search:
                    owner.ChangeSubState(StateMachineRoot.SubState.Search);
                    break;
                case StateMachineRoot.SubState.Chase:
                    owner.ChangeSubState(StateMachineRoot.SubState.Chase);
                    break;
                case StateMachineRoot.SubState.Escape:
                    owner.ChangeSubState(StateMachineRoot.SubState.Escape);
                    break;
            }
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Move State");
        }
    }
}
