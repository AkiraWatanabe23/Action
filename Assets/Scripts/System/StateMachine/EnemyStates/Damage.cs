using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage : EnemyStateBase, IDamage
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start damage state");
    }

    public override void OnUpdate(Enemy owner)
    {
        //todo : ダメージ処理
        ReceiveDamege(10);
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit damage state");
    }

    public void ReceiveDamege(int value)
    {
        throw new System.NotImplementedException();
    }
}
