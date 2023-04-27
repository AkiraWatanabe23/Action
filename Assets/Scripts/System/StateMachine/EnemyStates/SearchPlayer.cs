using UnityEngine;

[System.Serializable]
public class SearchPlayer : EnemyStateBase
{
    [Tooltip("シーン上のPlayer(アタッチしてください)")]
    [SerializeField] private GameObject _player = default;

    private int _posIndex = 0;

    public override void OnStart(Enemy owner)
    {
        Debug.Log("start search state");
    }

    public override void OnUpdate(Enemy owner)
    {
        Search(owner);
        Movement(owner);
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit search state");
    }

    /// <summary> 移動 </summary>
    public override void Movement(Enemy owner)
    {
        if (Mathf.ReferenceEquals(
            (owner.gameObject.transform.position - owner.Data.WanderingPos[_posIndex].position).sqrMagnitude, 0))
        {
            //目的地に到着したら次の目的地を設定
            var index = SetDestination(owner);
        }
        else
        {
            //到着していなかったら目的地に向かう
        }
    }

    /// <summary> 次の目的地のインデックスを取得 </summary>
    private int SetDestination(Enemy owner)
    {
        int index = Random.Range(0, owner.Data.WanderingPos.Count);

        if (index == _posIndex)
        {
            //同じ場所を選んだら、選び直し
            return SetDestination(owner);
        }

        return index;
    }

    /// <summary> Playerを探す </summary>
    private void Search(Enemy owner)
    {
        //playerが探索範囲内に入ったら追う
        var dir = _player.transform.position - owner.gameObject.transform.position;
        var dist = dir.sqrMagnitude;

        //cos(θ/2)
        var cosHalf = Mathf.Cos(owner.Data.SearchAngle / 2 * Mathf.Deg2Rad);

        //内積を取得する
        var innerProduct
            = Vector3.Dot(owner.gameObject.transform.forward, _player.transform.position.normalized);

        //視界に入っていて、距離が範囲内なら
        if (innerProduct > cosHalf && dist < owner.SqrDistance)
        {
            Debug.Log("find player");
            owner.SwitchState(Enemy.EnemyStates.Chase);
        }
    }
}
