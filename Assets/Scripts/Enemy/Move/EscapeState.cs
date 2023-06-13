using Constants;
using StateMachine;
using UnityEngine;

[System.Serializable]
public class EscapeState : MoveBaseState, IState
{
    [Range(0f, 5f)]
    [Tooltip("何秒おきに計測するか")]
    [SerializeField] private float _checkInterval = 1f;
    [Tooltip("逃走から徘徊に戻る距離")]
    [Range(1f, 10f)]
    [SerializeField] private float _returnDist = 1f;

    private float _checkTimer = 0f;

    public void OnEnter(StateMachineRoot owner)
    {
        Debug.Log("Enter Escape State");
        _checkTimer = 0f;
    }

    public void OnUpdate(StateMachineRoot owner)
    {
        Movement(owner);
    }

    public void OnExit(StateMachineRoot owner)
    {
        Debug.Log("Exit Escape State");
    }

    /// <summary> Playerから逃げる動き
    ///           （EnemyとPlayerとの逆ベクトルを取得し、その方向に移動）</summary>
    private void Movement(StateMachineRoot owner)
    {
        if (Anim)
        {
            owner.EnemyAnimation.ChangeAnimation(Consts.ANIM_SEARCH);
        }

        _checkTimer += Time.deltaTime;

        if (_checkTimer >= _checkInterval)
        {
            Vector3 direction = Enemy.position - Player.position;

            if (Vector3.SqrMagnitude(direction) > _returnDist * _returnDist)
            {
                //ある程度離れたら徘徊に戻る
                owner.ChangeState(StateMachineRoot.SubState.Search);
            }
            else
            {
                //まだ近かったら新たに場所を決めて逃げる
                Vector3 targetPos = Enemy.position + direction;

                Agent.SetDestination(targetPos);
                _checkTimer = 0f;
            }
        }

    }
}
