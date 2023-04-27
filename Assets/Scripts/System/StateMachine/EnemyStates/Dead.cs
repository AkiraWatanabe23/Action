using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : EnemyStateBase
{
    public override void OnStart()
    {
        Debug.Log("start dead state");
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        Debug.Log("exit dead state");
    }
}
