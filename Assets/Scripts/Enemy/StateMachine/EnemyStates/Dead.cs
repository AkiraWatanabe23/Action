using UnityEngine;

[System.Serializable]
public class Dead : EnemyStateBase
{
    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start dead state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit dead state");
    }
}
