using UnityEngine;

[System.Serializable]
public class SearchPlayer : EnemyStateBase
{
    private int _posIndex = 0;
    private float _stopping = 0f;

    private bool _isSwitch = false;

    public override void OnStart(Enemy owner)
    {
        //最初の目的地を設定
        _posIndex = SetDestinationIndex(owner);
        owner.Agent.SetDestination(owner.WanderPos[_posIndex].position);

        _stopping = owner.Agent.stoppingDistance;

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

    public override void Movement(Enemy owner)
    {
        var sqrMag
            = Vector3.SqrMagnitude(owner.gameObject.transform.position - owner.WanderPos[_posIndex].position);

        if (sqrMag < _stopping * _stopping)
        {
            if (!_isSwitch)
            {
                _isSwitch = true;
                //目的地に到着したら次の目的地を設定
                _posIndex = SetDestinationIndex(owner);
                Debug.Log("switch");
            }
        }
        owner.Agent.SetDestination(owner.WanderPos[_posIndex].position);
    }

    /// <summary> 次の目的地のインデックスを取得 </summary>
    private int SetDestinationIndex(Enemy owner)
    {
        int index = Random.Range(0, owner.WanderPos.Count);

        if (index == _posIndex)
        {
            //同じ場所を選んだら、選び直し
            return SetDestinationIndex(owner);
        }

        _isSwitch = false;
        return index;
    }

    /// <summary> Playerを探す </summary>
    private void Search(Enemy owner)
    {
        //playerが探索範囲内に入ったら追う
        var dir = owner.Player.transform.position - owner.gameObject.transform.position;
        var dist = dir.sqrMagnitude;

        //cos(θ/2)
        var cosHalf = Mathf.Cos(owner.Data.SearchAngle / 2 * Mathf.Deg2Rad);

        //内積を取得する
        var innerProduct
            = Vector3.Dot(owner.gameObject.transform.forward, owner.Player.transform.position.normalized);

        //視界に入っていて、距離が範囲内なら
        if (innerProduct > cosHalf && dist < owner.SqrDistance)
        {
            Debug.Log("find player");
            owner.SwitchState(Enemy.EnemyStates.Chase);
        }
    }
}
