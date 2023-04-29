using UnityEngine;

[System.Serializable]
public class Attack : EnemyStateBase
{
    public override void OnStart(EnemyStateMachine owner)
    {
        Debug.Log("start attack state");
    }

    public override void OnUpdate(EnemyStateMachine owner)
    {
        //todoFUŒ‚ˆ—(animationÄ¶Aƒ_ƒ[ƒWˆ—)

        //UŒ‚‚µ‚½‚çœpœj‚É–ß‚é
        owner.SwitchState(EnemyStateMachine.EnemyStates.Search);
    }

    public override void OnExit(EnemyStateMachine owner)
    {
        Debug.Log("exit attack state");
    }
}
