using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage : EnemyStateBase, IDamage
{
    public override void OnStart()
    {
        Debug.Log("start damage state");
    }

    public override void OnUpdate()
    {
        //todo : ダメージ処理
        ReceiveDamege(10);
    }

    public override void OnExit()
    {
        Debug.Log("exit damage state");
    }

    public void ReceiveDamege(int value)
    {
        throw new System.NotImplementedException();
    }
}
