using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Move : EnemyStateBase
{
    public override void OnStart()
    {
        Debug.Log("start move state");
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
    
    public override void OnExit()
    {
        Debug.Log("exit move state");
    }
}
