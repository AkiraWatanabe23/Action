using UnityEngine;

/// <summary> 行動関連のステートの基底クラス </summary>
public class ConductBaseState
{
    #region 変数一覧
    public EnemyData EnemyData { get; private set; }
    public Transform Enemy { get; private set; }
    public Animator Anim { get; private set; }
    #endregion

    public void Init(EnemyData enemyData, Transform enemy, Animator anim)
    {
        EnemyData = enemyData;
        Enemy = enemy;
        Anim = anim;
    }
}
