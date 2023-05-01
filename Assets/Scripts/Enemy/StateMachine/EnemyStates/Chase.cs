using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class Chase : EnemyStateBase
{
    [Tooltip("Playerに攻撃をする距離")]
    [Range(1f, 10f)]
    [SerializeField] private float _attackDist = 1f;
    [Tooltip("追跡から徘徊に戻る距離")]
    [Range(1f, 10f)]
    [SerializeField] private float _returnDist = 1f;

    private Animator _anim = default;

    #region EnemyControllerの参照を避けるための変数
    private NavMeshAgent _agent = default;
    private WanderingRange _wandering = default;
    private GameObject _player = default;
    private GameObject _enemy = default;
    #endregion

    public void Init(NavMeshAgent agent, WanderingRange wandering, GameObject player, GameObject enemy)
    {
        _agent = agent;
        _wandering = wandering;
        _player = player;
        _enemy = enemy;
    }

    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start chase state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        if (_wandering.IsMove)
        {
            Movement(owner);
        }
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit chase state");
    }

    /// <summary> 移動 </summary>
    public override void Movement(EnemyStateMachine owner)
    {
        if (_anim)
        {
            //移動Animation
        }

        _agent.SetDestination(_player.transform.position);

        var sqrMag
            = Vector3.SqrMagnitude(_enemy.transform.position - _player.transform.position);

        if (sqrMag < _attackDist * _attackDist)
        {
            //Playerとの距離がある程度まで縮まったら攻撃に遷移
            owner.SwitchState(EnemyStateMachine.EnemyStates.Attack);
        }

        if (sqrMag > _returnDist * _returnDist)
        {
            //Playerとの距離がある程度まで離れたらSearchに戻る
            owner.SwitchState(EnemyStateMachine.EnemyStates.Search);
        }
    }
}
