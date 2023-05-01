using UnityEngine;

[System.Serializable]
public class Damage : EnemyStateBase
{
    private Animator _anim = default;

    public void Init()
    {

    }

    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start damage state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        if (_anim)
        {
            //被ダメージAnimation
        }
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit damage state");
    }
}
