using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<EnemyController> _enemies = new();
    [SerializeField] private Transform _player = default;

    [SerializeField] private float _sqrValue = 2f;
    [SerializeField] private float _searchInterval = 1f;

    private float _timer = 0f;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out EnemyController enemy))
            {
                _enemies.Add(enemy);
            }
        }

        if (_player)
        {
            _enemies.ForEach(n => n.Player = _player);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _searchInterval)
        {
            SearchDitance();
            _timer = 0f;
        }
    }

    private void SearchDitance()
    {
        if (_player)
        {
            foreach (var enemy in _enemies)
            {
                //一定距離以内で探索開始
                if ((enemy.transform.position - _player.position).sqrMagnitude > _sqrValue)
                {
                    //追跡開始処理
                    enemy.Wandering.IsMove = true;
                    enemy.Wandering.SetCanvas?.Invoke(enemy.Wandering.IsMove);
                }
                else
                {
                    //追跡終了処理
                    enemy.Wandering.IsMove = false;
                    enemy.Wandering.SetCanvas?.Invoke(enemy.Wandering.IsMove);
                }
            }
        }
    }
}
