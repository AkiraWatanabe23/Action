using StateMachine;
using UnityEngine;

public class IdleState : StateTransitionBase
{
    public override void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Idle State");
    }

    public override void OnUpdate(StateMachineRoot owner)
    {
        throw new System.NotImplementedException();
    }
    public override void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Idle State");
    }
}
