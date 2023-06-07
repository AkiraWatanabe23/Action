using StateMachine;
using UnityEngine;

public class IdleState : IState
{
    private bool _isChangeState = false;

    public void Init()
    {

    }

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Idle State");
        _isChangeState = false;
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        //IdleState ... 基本的には何もしない

        //Playerが敵（自分）の一定範囲内に入ってきたらMoveStateに遷移
        if (_isChangeState)
        {
            Debug.Log("Playerが範囲内に侵入しました");
            owner.ChangeState(StateMachineRoot.SubState.Search);
        }
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Idle State");
    }

    public void TransitionFromIdle()
    {
        _isChangeState = true;
    }
}
