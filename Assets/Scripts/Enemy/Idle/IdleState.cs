using StateMachine;
using UnityEngine;
using Constants;

public class IdleState : IState
{
    private Animator _anim = default;
    private bool _isChangeState = false;

    public void Init(Animator anim)
    {
        _anim = anim;
    }

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Idle State");
        _isChangeState = false;
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        //IdleState ... 基本的には何もしない
        if (_anim)
        {
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_IDLE);
        }

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

    public void ExitIdle()
    {
        _isChangeState = true;
    }
}
