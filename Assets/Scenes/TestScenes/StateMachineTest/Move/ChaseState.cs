﻿using StateMachine;
using UnityEngine;

[System.Serializable]
public class ChaseState : MoveBaseState, IState
{
    [Tooltip("Playerに攻撃をする距離")]
    [Range(1f, 10f)]
    [SerializeField] private float _attackDist = 1f;
    [Tooltip("追跡から徘徊に戻る距離")]
    [Range(1f, 10f)]
    [SerializeField] private float _returnDist = 1f;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Chase State");
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        if (Wandering.IsMove)
        {
            Movement(owner);
        }
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Chase State");
    }

    /// <summary> 移動 </summary>
    private void Movement(StateMachineRoot owner)
    {
        if (Anim)
        {
            //移動Animation
        }

        Agent.SetDestination(Player.position);
        var sqrMag
            = Vector3.SqrMagnitude(Enemy.position - Player.position);

        if (sqrMag < _attackDist * _attackDist)
        {
            //Playerとの距離がある程度まで縮まったら攻撃に遷移
            owner.ChangeState(StateMachineRoot.SubState.Attack);
        }

        if (sqrMag > _returnDist * _returnDist)
        {
            //Playerとの距離がある程度まで離れたらSearchに戻る
            owner.ChangeState(StateMachineRoot.SubState.Search);
        }
    }
}
