using StateMachine;
using UnityEngine;

[System.Serializable]
public class DeathState : ConductBaseState, IState
{
    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Death State");
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        if (Anim)
        {
            //Aniamtion再生
        }
        //一旦非表示
        Enemy.gameObject.SetActive(false);
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Death State");
    }
}
