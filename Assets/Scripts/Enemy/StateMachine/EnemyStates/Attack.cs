using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    [SerializeField] private int _attackValue = 10;
    [SerializeField] private float _rayDist = 1f;

    private Animator _anim = default;

    #region EnemyControllerの参照を避けるための変数
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
        //攻撃処理
        if (Physics.Raycast(_enemy.position, _enemy.forward, out RaycastHit hit, _rayDist))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerController player))
            {
                if (_anim)
                {
                    //攻撃Animation
                }
                player.Health.ReceiveDamege(_data.AttackValue);
            }
        }

        //攻撃したら徘徊に戻る
        owner.SwitchState(EnemyStateMachine.EnemyStates.Search);
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit attack state");
    }
}
