namespace StateMachine
{
    public abstract class EnemyStateTransition
    {
        public abstract void OnEnter(EnemyStates owner);
        public abstract void OnUpdate(EnemyStates owner);
        public abstract void OnExit(EnemyStates owner);
    }
}
