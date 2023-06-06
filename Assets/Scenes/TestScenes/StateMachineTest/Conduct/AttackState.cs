using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    public class AttackState : ConductBaseState, IState
    {
        [SerializeField] private float _attackDiatance = 1f;

        public void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Attack State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            if (Anim)
            {

            }

            //ˆÈ‰º‰¼
            if (Physics.Raycast(Enemy.transform.position, Enemy.transform.forward, out RaycastHit hit, _attackDiatance))
            {
                if (hit.collider.gameObject.TryGetComponent(out PlayerController player))
                {
                    player.Health.ReceiveDamege(EnemyData.AttackValue);
                }
            }
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Attack State");
        }
    }
}
