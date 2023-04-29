using UnityEngine;

[System.Serializable]
public class SearchPlayer : EnemyStateBase
{
    [Tooltip("NavMeshAgent.stoppingDistance")]
    [SerializeField] private float _stopping = 1f;

    private int _posIndex = 0;

    public override void OnStart(EnemyStateMachine owner)
    {
        //ステート開始時の目的地を設定
        _posIndex = SetDestinationIndex(owner);
        owner.Agent.SetDestination(owner.Wandering.WanderingPos[_posIndex].position);

        owner.Agent.stoppingDistance = _stopping;

        Debug.Log("start search state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        if (owner.Wandering.IsMove)
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
        var sqrMag
            = Vector3.SqrMagnitude(owner.gameObject.transform.position - owner.Wandering.WanderingPos[_posIndex].position);

        if (sqrMag < _stopping * _stopping)
        {
            //目的地に到着したら次の目的地を設定
            _posIndex = SetDestinationIndex(owner);
            Debug.Log("switch");
        }
        owner.Agent.SetDestination(owner.Wandering.WanderingPos[_posIndex].position);
    }

    /// <summary> 次の目的地のインデックスを取得 </summary>
    private int SetDestinationIndex(EnemyStateMachine owner)
    {
        int index = Random.Range(0, owner.Wandering.WanderingPos.Length);

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
        var dir = owner.Player.transform.position - owner.gameObject.transform.position;
        var dist = dir.sqrMagnitude;

        //cos(θ/2)
        var cosHalf = Mathf.Cos(owner.Data.SearchAngle / 2 * Mathf.Deg2Rad);

        //内積を取得する
        var innerProduct
            = Vector3.Dot(owner.gameObject.transform.forward, owner.Player.transform.position.normalized);

        //視界に入っていて、距離が範囲内ならPlayerの追跡に切り替わる
        if (innerProduct > cosHalf && dist < owner.SqrDistance)
        {
            Debug.Log("find player");
            owner.SwitchState(EnemyStateMachine.EnemyStates.Chase);
        }
    }
}
