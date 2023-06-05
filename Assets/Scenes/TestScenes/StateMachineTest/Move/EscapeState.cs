using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    public class EscapeState : MoveBaseState, IState
    {
        [Tooltip("何秒おきに計測するか")]
        [SerializeField] private float _checkInterval = 1f;

        private float _checkTimer = 0f;

        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Escape State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            Movement();
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Escape State");
        }

        /// <summary> Playerから逃げる動き
        ///           （EnemyとPlayerとの逆ベクトルを取得し、その方向に移動）</summary>
        private void Movement()
        {
            _checkTimer += Time.deltaTime;

            if (_checkTimer >= _checkInterval)
            {
                Vector3 direction = Enemy.position - Player.position;
                Vector3 targetPos = Enemy.position + direction;

                Agent.SetDestination(targetPos);
                _checkTimer = 0f;
            }

        }
    }
}
