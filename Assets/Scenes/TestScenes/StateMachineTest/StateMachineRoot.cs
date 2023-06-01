using UnityEngine;

namespace StateMachine
{
    public class StateMachineRoot
    {
        private StateTransitionBase _currentState = default;

        private IdleState _idle = new();
        private MoveBaseState _move = new();
        private ConductState _conduct = new();

        public void Init()
        {
            //初期ステートの設定
            _currentState = _idle;
        }

        public void Update()
        {
            _currentState.OnUpdate(this);
        }

        private StateTransitionBase GetState(EnemyStates.BaseState state)
        {
            switch (state)
            {
                case EnemyStates.BaseState.Idle:
                    return _idle;
                case EnemyStates.BaseState.Move:
                    return _move;
                case EnemyStates.BaseState.Conduct:
                    return _conduct;
            }

            Debug.LogError("No State");
            return null;
        }

        public void ChangeState(EnemyStates.BaseState nextState)
        {
            _currentState.OnExit(this);
            _currentState = GetState(nextState);
            _currentState.OnEnter(this);
        }
    }
}
