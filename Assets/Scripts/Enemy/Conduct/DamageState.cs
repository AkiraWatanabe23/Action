using Constants;
using StateMachine;
using UnityEngine;

[System.Serializable]
public class DamageState : ConductBaseState, IState
{
    [Range(0f, 100f)]
    [Tooltip("ëÃóÕÇ™âΩäÑà»â∫Ç…Ç»Ç¡ÇΩÇÁPlayerÇ©ÇÁì¶Ç∞ÇÈÇ©(%)")]
    [SerializeField] private float _escapeValue = 40f;

    private ConductBaseState _conductBase = default;

    public float EscapeValue => _escapeValue * 0.01f;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Damage State");
        _conductBase = owner.Conduct;
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        //Animationçƒê∂å„Ç…úpújÇ…ñﬂÇÈ
        if (_conductBase.Anim)
        {
            //Animationçƒê∂
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_DAMAGE);
        }
        owner.ChangeState(StateMachineRoot.SubState.Search);
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Damage State");
    }
}
