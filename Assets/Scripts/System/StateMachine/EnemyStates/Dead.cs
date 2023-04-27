using UnityEngine;

[System.Serializable]
public class Dead : EnemyStateBase
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start dead state");
    }

    public override void OnUpdate(Enemy owner)
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit dead state");
    }
}
