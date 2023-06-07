using UnityEngine;

/// <summary> 行動関連のステートの基底クラス </summary>
public class ConductBaseState
{
    #region 変数一覧
    private EnemyData _enemyData = default;
    private Transform _enemy = default;
    private Animator _anim = default;

    public EnemyData EnemyData => _enemyData;
    public Transform Enemy => _enemy;
    public Animator Anim => _anim;
    #endregion

    public void Init(EnemyData enemyData, Transform enemy, Animator anim)
    {
        _enemyData = enemyData;
        _enemy = enemy;
        _anim = anim;
    }
}
