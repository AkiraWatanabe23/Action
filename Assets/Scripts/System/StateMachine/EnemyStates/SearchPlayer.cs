using UnityEngine;

[System.Serializable]
public class SearchPlayer : EnemyStateBase
{
    [Tooltip("シーン上のPlayer(アタッチしてください)")]
    [SerializeField] private GameObject _player = default;

    private bool _isFindPlayer = false;

    public override void OnStart(Enemy owner)
    {
        _isFindPlayer = false;
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

    private void Movement(Enemy owner)
    {

    }
}
