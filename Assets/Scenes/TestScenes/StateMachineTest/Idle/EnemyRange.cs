using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private List<EnemyAttachment> _enemies = new();

    public void Init()
    {
        //この範囲内の敵をListに格納
        //===============ここがなんか気になるので後で直す===============
        for (int i = 0; i < transform.childCount; i++)
        {
            _enemies.Add(transform.GetChild(i).GetComponent<EnemyAttachment>());
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

                var current = enemy.Root.CurrentState;

                if (current == enemy.Root.Idle)
                {
                    enemy.Root.Idle.TransitionFromIdle();
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

                var current = enemy.Root.CurrentState;

                if (current != enemy.Root.Idle)
                {
                    enemy.Root.ChangeState(StateMachine.StateMachineRoot.BaseState.Idle);
                }
            }
        }
    }
}
