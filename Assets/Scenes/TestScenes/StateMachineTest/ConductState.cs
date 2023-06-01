using StateMachine;
using UnityEngine;

public class ConductState : EnemyStateTransition
{
    private ConductChildState _conductChild = ConductChildState.Attack;

    public ConductChildState ConductChild => _conductChild;

    public override void OnEnter(EnemyStates owner)
    {
        Debug.Log("Enter Conduct State");
    }

    public override void OnUpdate(EnemyStates owner)
    {
        throw new System.NotImplementedException();
    }
    public override void OnExit(EnemyStates owner)
    {
        Debug.Log("Exit Conduct State");
    }

    public enum ConductChildState
    {
        Attack,
        Damage,
        Death
    }
}
