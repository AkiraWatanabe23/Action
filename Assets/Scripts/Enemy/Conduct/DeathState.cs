using StateMachine;
using UnityEngine;

[System.Serializable]
public class DeathState : ConductBaseState, IState
{
    private ConductBaseState _conductBase = default;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Death State");
        _conductBase = owner.Conduct;
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        //ˆê’U”ñ•\Ž¦
        _conductBase.Enemy.gameObject.SetActive(false);
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Death State");
    }
}
