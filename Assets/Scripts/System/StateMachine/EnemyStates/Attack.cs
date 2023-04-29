using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    public override void OnStart(Enemy owner)
    {
        Debug.Log("start attack state");
    }

    public override void OnUpdate(Enemy owner)
    {
        //todoFU(animationΔΆA_[W)

        //U΅½ηpjΙίι
        owner.SwitchState(Enemy.EnemyStates.Search);
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit attack state");
    }
}
