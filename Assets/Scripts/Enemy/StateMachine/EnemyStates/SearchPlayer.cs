using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class SearchPlayer : EnemyStateBase
{
    [Tooltip("NavMeshAgent.stoppingDistance")]
    [SerializeField] private float _stopping = 1f;

    private int _posIndex = 0;
    private Animator _anim = default;

    #region EnemyControllerの参照を避けるための変数
    private EnemyData _data = default;
    private NavMeshAgent _agent = default;
    private WanderingRange _wandering = default;
    private GameObject _player = default;
    private GameObject _enemy = default;
    private float _sqrDistance = 1f;
    #endregion

    public void Init(EnemyData data, NavMeshAgent agent, WanderingRange wandering, GameObject player, GameObject enemy, float distance)
    {
        _data = data;
        _agent = agent;
        _wandering = wandering;
        _player = player;
        _enemy = enemy;
        _sqrDistance = distance;
    }

    public override void OnStart(EnemyStateMachine owner)
    {
        //ステート開始時の目的地を設定
        _posIndex = SetDestinationIndex(owner);
        _agent.SetDestination(_wandering.WanderingPos[_posIndex].position);

        _agent.stoppingDistance = _stopping;

        Debug.Log("start search state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        if (_wandering.IsMove)
        {
            Search(owner);
            Movement(owner);
        }
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit search state");
    }

    /// <summary> 移動 </summary>
    public override void Movement(EnemyStateMachine owner)
    {
        if (_anim)
        {
            //歩行Animation
        }

        var sqrMag
            = Vector3.SqrMagnitude(_enemy.transform.position - _wandering.WanderingPos[_posIndex].position);

        if (sqrMag < _stopping * _stopping)
        {
            //目的地に到着したら次の目的地を設定
            _posIndex = SetDestinationIndex(owner);
            Debug.Log("switch");
        }
        _agent.SetDestination(_wandering.WanderingPos[_posIndex].position);
    }

    /// <summary> 次の目的地のインデックスを取得 </summary>
    private int SetDestinationIndex(EnemyStateMachine owner)
    {
        int index = Random.Range(0, _wandering.WanderingPos.Length);

        if (index == _posIndex)
        {
            //同じ場所を選んだら、選び直し
            return SetDestinationIndex(owner);
        }

        return index;
    }

    /// <summary> Playerを探す </summary>
    private void Search(EnemyStateMachine owner)
    {
        var dir = _player.transform.position - _enemy.transform.position;
        var dist = dir.sqrMagnitude;

        //cos(θ/2)
        var cosHalf = Mathf.Cos(_data.SearchAngle / 2 * Mathf.Deg2Rad);

        //内積を取得する
        var innerProduct
            = Vector3.Dot(_enemy.transform.forward, _player.transform.position.normalized);

        //視界に入っていて、距離が範囲内ならPlayerの追跡に切り替わる
        if (innerProduct > cosHalf && dist < _sqrDistance)
        {
            Debug.Log("find player");
            owner.SwitchState(EnemyStateMachine.EnemyStates.Chase);
        }
    }
}
