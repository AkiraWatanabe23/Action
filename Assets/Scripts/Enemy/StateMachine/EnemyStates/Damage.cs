using UnityEngine;

[System.Serializable]
public class Damage : EnemyStateBase
{
    public void Init()
    {

    }

    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start damage state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {

    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit damage state");
    }
}
