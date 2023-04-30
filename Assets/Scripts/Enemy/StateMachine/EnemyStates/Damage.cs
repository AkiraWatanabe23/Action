using UnityEngine;

[System.Serializable]
public class Damage : EnemyStateBase, IDamage
{
    private int _hp = 100;

    public void Init(int hp)
    {
        _hp = hp;
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

    public void ReceiveDamege(int value)
    {
        _hp -= value;
    }
}
