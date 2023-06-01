using StateMachine;
using UnityEngine;

public class IdleState : EnemyStateTransition
{
    public override void OnEnter(EnemyStates owner)
    {
        Debug.Log("Enter Idle State");
    }

    public override void OnUpdate(EnemyStates owner)
    {
        throw new System.NotImplementedException();
    }
    public override void OnExit(EnemyStates owner)
    {
        Debug.Log("Exit Idle State");
    }
}
