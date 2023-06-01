namespace StateMachine
{
    public abstract class EnemyStateTransition
    {
        public abstract void OnStart(EnemyStates owner);
        public abstract void OnUpdate(EnemyStates owner);
        public abstract void OnExit(EnemyStates owner);
    }
}
