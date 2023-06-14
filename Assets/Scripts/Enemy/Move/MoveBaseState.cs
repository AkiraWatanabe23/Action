using UnityEngine;
using UnityEngine.AI;

/// <summary> 動き関連のステートの基底クラス </summary>
public class MoveBaseState
{
    #region 変数一覧
    public EnemyData EnemyData { get; private set; }
    public WanderingRange Wandering { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    public Transform Player { get; private set; }
    public Transform Enemy { get; private set; }
    public float SqrDistance { get; private set; }
    public Animator Anim { get; private set; }
    #endregion

    public void Init(EnemyData enemyData, WanderingRange wandering, NavMeshAgent agent,
                     Transform player, Transform enemy, float sqrDistance,
                     Animator anim)
    {
        EnemyData = enemyData;
        Wandering = wandering;
        Agent = agent;
        Player = player;
        Enemy = enemy;
        SqrDistance = sqrDistance;
        Anim = anim;
    }
}
