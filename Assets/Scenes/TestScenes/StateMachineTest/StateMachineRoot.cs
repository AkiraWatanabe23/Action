namespace StateMachine
{
    public class StateMachineRoot
    {
        private EnemyStates.BaseState _currentState = EnemyStates.BaseState.Idle;

        public EnemyStates.BaseState CurrentState => _currentState;
    }
}
