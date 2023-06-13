using Constants;
using StateMachine;
using UnityEngine;

[System.Serializable]
public class DamageState : ConductBaseState, IState
{
    [Range(0f, 100f)]
    [Tooltip("体力が何割以下になったらPlayerから逃げるか(%)")]
    [SerializeField] private float _escapeValue = 40f;

    public float EscapeValue => _escapeValue * 0.01f;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Damage State");
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        //Animation再生後に徘徊に戻る
        if (Anim)
        {
            //Animation再生
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_DAMAGE);
        }
        owner.ChangeState(StateMachineRoot.SubState.Search);
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Damage State");
    }
}
