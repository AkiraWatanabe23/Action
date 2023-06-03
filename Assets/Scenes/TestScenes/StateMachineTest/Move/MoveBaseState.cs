using UnityEngine;

namespace StateMachine
{
    public class MoveBaseState : State
    {
        private StateFlag _flag = StateFlag.None;

        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Move State");

            //ここで子ステートへの遷移
            switch (_flag)
            {
                case StateFlag.Search:
                    owner.ChangeSubState(StateMachineRoot.SubState.Search);
                    break;
                case StateFlag.Chase:
                    owner.ChangeSubState(StateMachineRoot.SubState.Chase);
                    break;
                case StateFlag.Escape:
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

        public void SelectFlag(StateFlag flag)
        {
            _flag = flag;
        }

        public enum StateFlag
        {
            None,
            Search,
            Chase,
            Escape,
        }
    }
}
