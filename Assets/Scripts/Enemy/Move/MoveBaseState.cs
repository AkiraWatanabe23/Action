using UnityEngine;
using UnityEngine.AI;

/// <summary> 動き関連のステートの基底クラス </summary>
public class MoveBaseState
{
    #region 変数一覧
    private EnemyData _enemyData = default;
    private WanderingRange _wandering = default;
    private NavMeshAgent _agent = default;
    private Transform _player = default;
    private Transform _enemy = default;
    private float _sqrDistance = 1f;
    private Animator _anim = default;

    public EnemyData EnemyData => _enemyData;
    public WanderingRange Wandering => _wandering;
    public NavMeshAgent Agent => _agent;
    public Transform Player => _player;
    public Transform Enemy => _enemy;
    public float SqrDistance => _sqrDistance;
    public Animator Anim => _anim;
    #endregion

    public void Init(EnemyData enemyData, WanderingRange wandering, NavMeshAgent agent,
                     Transform player, Transform enemy, float sqrDistance,
                     Animator anim)
    {
        _enemyData = enemyData;
        _wandering = wandering;
        _agent = agent;
        _player = player;
        _enemy = enemy;
        _sqrDistance = sqrDistance;
        _anim = anim;
    }
}
