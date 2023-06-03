using UnityEngine;

namespace StateMachine
{
    public class ConductBaseState : State
    {
        private StateFlag _flag = StateFlag.None;

        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Conduct State");

            //ここで子ステートへの遷移
            switch (_flag)
            {
                case StateFlag.Attack:
                    owner.ChangeSubState(StateMachineRoot.SubState.Attack);
                    break;
                case StateFlag.Damage:
                    owner.ChangeSubState(StateMachineRoot.SubState.Damage);
                    break;
                case StateFlag.Death:
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

        public void SelectFlag(StateFlag flag)
        {
            _flag = flag;
        }

        public enum StateFlag
        {
            None,
            Attack,
            Damage,
            Death,
        }
    }
}
