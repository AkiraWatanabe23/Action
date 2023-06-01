using StateMachine;
using UnityEngine;

public class SearchState : StateTransitionBase
{
    public override void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Search State");
    }

    public override void OnUpdate(StateMachineRoot owner)
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Search State");
    }
}
