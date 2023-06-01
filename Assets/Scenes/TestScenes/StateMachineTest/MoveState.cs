using StateMachine;
using UnityEngine;

public class MoveState : EnemyStateTransition
{
    private MoveChildState _moveChild = MoveChildState.Search;

    public MoveChildState MoveChild => _moveChild;

    public override void OnEnter(EnemyStates owner)
    {
        Debug.Log("Enter Move State");
    }

    public override void OnUpdate(EnemyStates owner)
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit(EnemyStates owner)
    {
        Debug.Log("Exit Move State");
    }

    public enum MoveChildState
    {
        Search,
        Chase,
        RunAway
    }
}
