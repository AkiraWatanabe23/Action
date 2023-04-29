using UnityEngine;

[System.Serializable]
public class Chase : EnemyStateBase
{
    [Tooltip("Playerに攻撃をする距離")]
    [Range(1f, 10f)]
    [SerializeField] private float _attackDistance = 1f;
    [Tooltip("追跡から徘徊に戻る距離")]
    [Range(1f, 10f)]
    [SerializeField] private float _returnDistance = 1f;

    public override void OnStart(Enemy owner)
    {
        Debug.Log("start chase state");
    }

    public override void OnUpdate(Enemy owner)
    {
        if (owner.Wandering.IsMove)
        {
            Movement(owner);
        }
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit chase state");
    }

    /// <summary> 移動 </summary>
    public override void Movement(Enemy owner)
    {
        owner.Agent.SetDestination(owner.Player.transform.position);

        var sqrMag
            = Vector3.SqrMagnitude(owner.gameObject.transform.position - owner.Player.transform.position);

        if (sqrMag < _attackDistance * _attackDistance)
        {
            //TODO：Playerとの距離がある程度まで縮まったら攻撃に遷移
            owner.SwitchState(Enemy.EnemyStates.Attack);
        }

        if (sqrMag > _returnDistance * _returnDistance)
        {
            //TODO：Playerとの距離がある程度まで離れたらSearchに戻る
            owner.SwitchState(Enemy.EnemyStates.Search);
        }
    }
}
