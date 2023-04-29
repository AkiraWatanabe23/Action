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
        //todoFUŒ‚ˆ—(animationÄ¶Aƒ_ƒ[ƒWˆ—)

        //UŒ‚‚µ‚½‚çœpœj‚É–ß‚é
        owner.SwitchState(Enemy.EnemyStates.Search);
    }

    public override void OnExit(Enemy owner)
    {
        Debug.Log("exit attack state");
    }
}
