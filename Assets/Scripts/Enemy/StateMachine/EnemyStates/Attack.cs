using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    [SerializeField] private int _attackValue = 10;
    [SerializeField] private float _rayDist = 1f;

    private Animator _anim = default;

    #region EnemyController‚ÌQÆ‚ğ”ğ‚¯‚é‚½‚ß‚Ì•Ï”
    private EnemyData _data = default;
    private Transform _enemy = default;
    #endregion

    public void Init(EnemyData data, Transform enemy)
    {
        _data = data;
        _enemy = enemy;
    }

    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start attack state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        //UŒ‚ˆ—
        if (Physics.Raycast(_enemy.position, _enemy.forward, out RaycastHit hit, _rayDist))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerController player))
            {
                if (_anim)
                {
                    //UŒ‚Animation
                }
                player.Health.ReceiveDamege(_data.AttackValue);
            }
        }

        //UŒ‚‚µ‚½‚çœpœj‚É–ß‚é
        owner.SwitchState(EnemyStateMachine.EnemyStates.Search);
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit attack state");
    }
}
