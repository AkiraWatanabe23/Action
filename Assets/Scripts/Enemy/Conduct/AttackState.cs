using Constants;
using StateMachine;
using UnityEngine;

[System.Serializable]
public class AttackState : ConductBaseState, IState
{
    [SerializeField] private Vector3 _attackOffset = Vector3.zero;
    [Range(1f, 10f)]
    [Tooltip("çUåÇÇÇ∑ÇÈãóó£(Raycast)")]
    [SerializeField] private float _attackDistance = 1f;

    private ConductBaseState _conductBase = default;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Attack State");
        _conductBase = owner.Conduct;
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        if (Anim)
        {
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_ATTACK);
        }

        //à»â∫âº
        if (Physics.Raycast(Enemy.transform.position + _attackOffset, Enemy.transform.forward, out RaycastHit hit, _attackDistance))
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
