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
        _posIndex = SetDestinationIndex();
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
            //歩行Animation
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_SEARCH);
        }

        var dir = _moveBase.Player.position - _moveBase.Enemy.position;
        var dist = dir.sqrMagnitude;

        //cos(θ/2)
        var cosHalf = Mathf.Cos(_moveBase.EnemyData.SearchAngle / 2 * Mathf.Deg2Rad);

        //内積を取得する
        var innerProduct
            = Vector3.Dot(_moveBase.Enemy.forward, _moveBase.Player.position.normalized);

        //視界に入っていて、距離が範囲内ならPlayerの追跡に切り替わる
        if (innerProduct > cosHalf && dist < _moveBase.SqrDistance)
        {
            Debug.Log("find player");
            owner.ChangeState(StateMachineRoot.SubState.Chase);
        }
    }

    /// <summary> 移動 </summary>
    private void Movement()
    {
        //var sqrMag
        //    = Vector3.SqrMagnitude(_moveBase.Enemy.position - _moveBase.Wandering.WanderingPos[_posIndex].position);
        var sqrDistance = Mathf.Pow(_moveBase.Agent.remainingDistance, 2);
        var sqrStopping = Mathf.Pow(_moveBase.Agent.stoppingDistance, 2);


        if (sqrDistance <= sqrStopping)
        {
            //目的地に到着したら次の目的地を設定
            _posIndex = SetDestinationIndex();
            Debug.Log("Change Destination");
            _moveBase.Agent.SetDestination(_moveBase.Wandering.WanderingPos[_posIndex].position);
        }
    }

    /// <summary> 次の目的地のインデックスを取得 </summary>
    private int SetDestinationIndex()
    {
        int index = Random.Range(0, _moveBase.Wandering.WanderingPos.Length);

        if (index == _posIndex)
        {
            //同じ場所を選んだら、選び直し
            Debug.Log("選び直し");
            return SetDestinationIndex();
        }

        return index;
    }
}
