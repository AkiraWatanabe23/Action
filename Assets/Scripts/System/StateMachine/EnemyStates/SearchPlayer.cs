using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : EnemyStateBase
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start search state");
    }

    public override void OnUpdate(Enemy owner)
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit search state");
    }
}
