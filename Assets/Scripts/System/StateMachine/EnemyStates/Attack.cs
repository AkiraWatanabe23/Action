using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start attack state");
    }

    public override void OnUpdate(Enemy owner)
    {
        //todo�F�U������(animation�Đ��A�_���[�W����)

        //�U��������p�j�ɖ߂�
        owner.SwitchState(Enemy.EnemyStates.Search);
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit attack state");
    }
}
