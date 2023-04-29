using UnityEngine;

[System.Serializable]
public class Damage : EnemyStateBase, IDamage
{
    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start damage state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        //todo : ダメージ処理
        ReceiveDamege(10);
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit damage state");
    }

    public void ReceiveDamege(int value)
    {
        throw new System.NotImplementedException();
    }
}
