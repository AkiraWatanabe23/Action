using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Idle : EnemyStateBase
{
    public override void OnStart()
    {
        Debug.Log("start idle state");
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        Debug.Log("exit idle state");
    }
}
