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
        //todo : �U������

        //animation�Đ��A�_���[�W����
    }

    public override void OnExit()
    {
        Debug.Log("exit attack state");
    }
}
