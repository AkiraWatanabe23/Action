using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Tooltip("視界範囲")]
    public float SearchAngle;
    [Tooltip("視界の距離")]
    public float SearchDistance;
    [Tooltip("徘徊する場所")]
    public List<Transform> _wanderingPos;
}
