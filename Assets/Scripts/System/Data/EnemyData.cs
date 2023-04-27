using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Tooltip("視界範囲(視界の正面から半分)")]
    public float SearchAngle;
    [Tooltip("視界の距離")]
    public float SearchDistance;
    [Tooltip("徘徊する場所(登録した箇所を徘徊する)")]
    public List<Transform> WanderingPos;
}
