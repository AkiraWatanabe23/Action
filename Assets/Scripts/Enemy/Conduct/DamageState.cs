using Constants;
using StateMachine;
using UnityEngine;

[System.Serializable]
public class DamageState : ConductBaseState, IState
{
    [Range(0f, 100f)]
    [Tooltip("�̗͂������ȉ��ɂȂ�����Player���瓦���邩(%)")]
    [SerializeField] private float _escapeValue = 40f;

    public float EscapeValue => _escapeValue * 0.01f;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Damage State");
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        //Animation�Đ���ɜp�j�ɖ߂�
        if (Anim)
        {
            //Animation�Đ�
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_DAMAGE);
        }
        owner.ChangeState(StateMachineRoot.SubState.Search);
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Damage State");
    }
}
