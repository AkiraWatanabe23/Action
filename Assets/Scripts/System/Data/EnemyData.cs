using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Header("移動ステータス")]
    [Tooltip("視界範囲(視界の正面から半分)")]
    public float SearchAngle;
    [Tooltip("視界の距離")]
    public float SearchDistance;

    [Header("ステータス一覧")]
    public int MaxHP;
    public int MoveSpeed;
    public int AttackValue;
}
