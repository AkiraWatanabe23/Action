using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private List<EnemyController> _enemies = new();

    public void Init()
    {
        //この範囲内の敵をListに格納
        //===============ここが違う気がするので後で直す===============
        for (int i = 0; i < transform.childCount; i++)
        {
            _enemies.Add(transform.GetChild(i).GetComponent<EnemyController>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            //IdleStateの敵を起こす
            foreach (var enemy in _enemies)
            {
                if (enemy == null) continue;

                var current = enemy.StateMachine.CurrentState;

                if (current == enemy.StateMachine.Idle)
                {
                    enemy.StateMachine.Idle.ExitIdle();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            //Playerが範囲外に出たらIdleStateに戻る
            foreach (var enemy in _enemies)
            {
                if (enemy == null) continue;

                var current = enemy.StateMachine.CurrentState;

                if (current != enemy.StateMachine.Idle)
                {
                    enemy.StateMachine.ChangeState(StateMachine.StateMachineRoot.BaseState.Idle);
                }
            }
        }
    }
}
