namespace StateMachine
{
    public abstract class StateTransitionBase
    {
        public abstract void OnEnter(StateMachineRoot owner);
        public abstract void OnUpdate(StateMachineRoot owner);
        public abstract void OnExit(StateMachineRoot owner);
    }
}
