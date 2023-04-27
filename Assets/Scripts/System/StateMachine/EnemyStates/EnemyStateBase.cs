using UnityEngine;

public abstract class EnemyStateBase
{
    public abstract void OnStart(Enemy owner);
    public abstract void OnUpdate(Enemy owner);
    public abstract void OnExit(Enemy owner);
}
