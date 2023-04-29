using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Header("移動ステータス")]
    [Tooltip("視界範囲(視界の正面から半分)")]
    public float SearchAngle;
    [Tooltip("視界の距離")]
    public float SearchDistance;
    [Tooltip("徘徊する場所の中心点")]
    public Transform WanderingPos;
    [Tooltip("Enemyが徘徊する円周の半径")]
    public int SearchRadius;

    [Header("ステータス一覧")]
    public int HP;
    public int MaxHP;
    public int MoveSpeed;
    public int AttackValue;
}
