namespace StateMachine
{
    public class StateMachineRoot
    {
        private EnemyStateTransition _currentState = default;

        //private EnemyStates.BaseState _currentState = EnemyStates.BaseState.Idle;

        private IdleState _idle = new();
        private MoveState _move = new();
        private ConductState _conduct = new();

        //public EnemyStates.BaseState CurrentState => _currentState;

        public void Init()
        {
            //初期ステートの設定
            _currentState = _idle;
        }
    }
}
