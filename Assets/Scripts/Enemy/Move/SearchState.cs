using Constants;
using StateMachine;
using UnityEngine;

[System.Serializable]
public class SearchState : MoveBaseState, IState
{
    [Range(0.1f, 1f)]
    [Tooltip("NavMeshAgent.stoppingDistance")]
    [SerializeField] private float _stopping = 0.5f;

    private int _posIndex = 0;
    private MoveBaseState _moveBase = default;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Search State");
        _moveBase = owner.Move;

        //ステート開始時の目的地を設定
        _posIndex = GetDestinationIndex();
        _moveBase.Agent.SetDestination(_moveBase.Wandering.WanderingPos[_posIndex].position);
        _moveBase.Agent.stoppingDistance = _stopping;
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        if (_moveBase.Wandering.IsMove)
        {
            Search(owner);
            Movement();
        }
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Search State");
    }

    /// <summary> Playerを探す </summary>
    private void Search(StateMachineRoot owner)
    {
        if (_moveBase.Anim)
        {
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_SEARCH);
        }

        //Playerが視界に入っていたら追跡に切り替わる
        if (PlayerVisible())
        {
            Debug.Log("find player");
            owner.ChangeState(StateMachineRoot.SubState.Chase);
        }
    }

    private void Movement()
    {
        var sqrDistance = Mathf.Pow(_moveBase.Agent.remainingDistance, 2);
        var sqrStopping = Mathf.Pow(_moveBase.Agent.stoppingDistance, 2);

        if (sqrDistance <= sqrStopping)
        {
            //目的地に到着したら次の目的地を設定
            _posIndex = GetDestinationIndex();
            _moveBase.Agent.SetDestination(_moveBase.Wandering.WanderingPos[_posIndex].position);
            Debug.Log("Change Destination");
        }
    }

    /// <summary> 次の目的地のインデックスを取得 </summary>
    private int GetDestinationIndex()
    {
        int index = Random.Range(0, _moveBase.Wandering.WanderingPos.Length);

        if (index == _posIndex)
        {
            Debug.Log("徘徊地点選び直し");
            return GetDestinationIndex();
        }
        return index;
    }

    /// <summary> 視界判定 </summary>
    private bool PlayerVisible()
    {
        var myPos = _moveBase.Enemy.position;
        var target = _moveBase.Player.position;

        var dir = target - myPos;
        var sqrDist = dir.sqrMagnitude;

        //cos(θ/ 2 )
        var cosHalf = Mathf.Cos(_moveBase.EnemyData.SearchAngle / 2 * Mathf.Deg2Rad);

        //内積を取得する
        var innerProduct
            = Vector3.Dot(_moveBase.Enemy.forward, target.normalized);

        return innerProduct > cosHalf && sqrDist < _moveBase.SqrDistance;
    }
}
