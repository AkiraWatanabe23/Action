using StateMachine;

public class MoveState : EnemyStateTransition
{
    private MoveChildState _moveChild = MoveChildState.Search;

    public MoveChildState MoveChild => _moveChild;

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

    public enum MoveChildState
    {
        Search,
        Chase,
        RunAway
    }
}
