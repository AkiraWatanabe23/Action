using Constants;
using StateMachine;
using UnityEngine;

[System.Serializable]
public class AttackState : ConductBaseState, IState
{
    [Range(1f, 10f)]
    [Tooltip("�U�������鋗��")]
    [SerializeField] private float _attackDiatance = 1f;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Attack State");
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        if (Anim)
        {
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_ATTACK);
        }

        //�ȉ���
        if (Physics.Raycast(Enemy.transform.position, Enemy.transform.forward, out RaycastHit hit, _attackDiatance))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerController player))
            {
                player.Health.ReceiveDamege(EnemyData.AttackValue);
            }
            owner.ChangeState(StateMachineRoot.SubState.Search);
        }
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Attack State");
    }
}
