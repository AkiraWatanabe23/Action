using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    public override void OnStart()
    {
        Debug.Log("start attack state");
    }

    public override void OnUpdate()
    {
        //todo : 攻撃処理

        //animation再生、ダメージ処理
    }

    public override void OnExit()
    {
        Debug.Log("exit attack state");
    }
}
