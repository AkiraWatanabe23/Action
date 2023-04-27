using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : EnemyStateBase
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start chase state");
    }

    public override void OnUpdate(Enemy owner)
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit chase state");
    }
}
