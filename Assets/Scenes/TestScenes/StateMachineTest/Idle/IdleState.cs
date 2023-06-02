using StateMachine;
using UnityEngine;

public class IdleState : StateTransitionBase
{
    private bool _isChangeState = false;

    public bool IsChangeState { get => _isChangeState; set => _isChangeState = value; }

    public void Init()
    {
        //必要な値の初期化
    }

    public override void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Idle State");
        _isChangeState = false;
    }

    public override void OnUpdate(StateMachineRoot owner)
    {
        //IdleState ... 基本的には何もしない

        //Playerが敵（自分）の一定範囲内に入ってきたらMoveStateに遷移
        if (_isChangeState)
        {
            Debug.Log("Playerが範囲内に侵入しました");
            owner.ChangeState(StateMachineRoot.BaseState.Move);
        }
    }

    public override void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Idle State");
    }
}
