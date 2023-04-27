using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start attack state");
    }

    public override void OnUpdate(Enemy owner)
    {
        //todo : 攻撃処理

        //animation再生、ダメージ処理
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit attack state");
    }
}
