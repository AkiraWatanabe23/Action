namespace StateMachine
{
    public abstract class SubState : State
    {
        protected State _currentState = default;

        public State CurrentState{ get => _currentState; set => _currentState = value; }
    }
}
