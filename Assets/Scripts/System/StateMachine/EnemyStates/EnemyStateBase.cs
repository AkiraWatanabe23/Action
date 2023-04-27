using UnityEngine;

public abstract class EnemyStateBase
{
    public abstract void OnStart(Enemy owner);
    public abstract void OnUpdate(Enemy owner);
    public abstract void OnExit(Enemy owner);

    /// <summary> 移動系のクラスのみ実装 </summary>
    public virtual void Movement(Enemy owner) { }
}
