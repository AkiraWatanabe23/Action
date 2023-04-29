﻿using UnityEngine;

[System.Serializable]
public class Chase : EnemyStateBase
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start chase state");
    }

    public override void OnUpdate(Enemy owner)
    {
        if (owner.Wandering.IsMove)
        {
            Movement(owner);
        }
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit chase state");
    }

    /// <summary> 移動 </summary>
    public override void Movement(Enemy owner)
    {
        owner.Agent.SetDestination(owner.Player.transform.position);

        //TODO：Playerとの距離がある程度まで縮まったら攻撃に遷移
        //                                  離れたらSearchに戻る
    }
}