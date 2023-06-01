using UnityEngine;

namespace StateMachine
{
    public class StateMachineRoot
    {
        private StateTransitionBase _currentState = default;

        //各親ステート
        private IdleState _idle = new();
        private MoveBaseState _move = new();
        private ConductState _conduct = new();

        public void Init()
        {
            //ここで必要な値の初期化を行う

            //初期ステートの設定
            _currentState = _idle;
        }

        public void Update()
        {
            _currentState.OnUpdate(this);
        }

        private StateTransitionBase GetState(BaseState state)
        {
            switch (state)
            {
                case BaseState.Idle:
                    return _idle;
                case BaseState.Move:
                    return _move;
                case BaseState.Conduct:
                    return _conduct;
            }

            Debug.LogError("No State");
            return null;
        }

        public void ChangeState(BaseState nextState)
        {
            _currentState.OnExit(this);
            _currentState = GetState(nextState);
            _currentState.OnEnter(this);
        }

        public enum BaseState
        {
            Idle,
            Move,
            Conduct
        }
    }
}
