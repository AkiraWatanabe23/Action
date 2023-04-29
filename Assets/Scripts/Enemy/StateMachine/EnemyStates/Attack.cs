using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start attack state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        //todo�F�U������(animation�Đ��A�_���[�W����)

        //�U��������p�j�ɖ߂�
        owner.SwitchState(EnemyStateMachine.EnemyStates.Search);
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit attack state");
    }
}
