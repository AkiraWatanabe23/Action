using UnityEngine;

[System.Serializable]
public class Dead : EnemyStateBase
{
    private Animator _anim = default;

    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start dead state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        if (_anim)
        {
            //倒れる感じのAnimation
        }
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit dead state");
    }
}
