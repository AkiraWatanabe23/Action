using StateMachine;

public class ConductState : EnemyStateTransition
{
    private ConductChildState _conductChild = ConductChildState.Attack;

    public ConductChildState ConductChild => _conductChild;

    public override void OnStart(EnemyStates owner)
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate(EnemyStates owner)
    {
        throw new System.NotImplementedException();
    }
    public override void OnExit(EnemyStates owner)
    {
        throw new System.NotImplementedException();
    }

    public enum ConductChildState
    {
        Attack,
        Damage,
        Death
    }
}
