using UnityEngine;

namespace StateMachine
{
    public class MoveBaseState : State
    {
        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Move State");

            //ここで子ステートへの遷移（条件を設定する）
            owner.ChangeSubState(StateMachineRoot.SubState.Search);
            owner.ChangeSubState(StateMachineRoot.SubState.Chase);
            owner.ChangeSubState(StateMachineRoot.SubState.Escape);
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
