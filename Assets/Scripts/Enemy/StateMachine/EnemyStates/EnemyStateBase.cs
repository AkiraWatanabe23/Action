public abstract class EnemyStateBase
{
    public abstract void OnStart(EnemyStateMachine owner);
    public abstract void OnUpdate(EnemyStateMachine owner);
    public abstract void OnExit(EnemyStateMachine owner);

    /// <summary> 移動系ステートのクラスのみ実装 </summary>
    public virtual void Movement(EnemyStateMachine owner) { }
}
