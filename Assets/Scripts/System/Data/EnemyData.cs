using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Tooltip("視界範囲(視界の正面から半分)")]
    public float SearchAngle;
    [Tooltip("視界の距離")]
    public float SearchDistance;
    [Tooltip("徘徊する場所の中心点")]
    public Transform WanderingPos;
    [Tooltip("Enemyが徘徊する円周の半径")]
    public int SearchRadius;
    [Tooltip("徘徊する円周内に何ヶ所の目的地を設定するか")]
    public int WanderPosCount;
}
