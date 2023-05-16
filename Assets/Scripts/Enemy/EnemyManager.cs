using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<EnemyController> _enemies = new();

    [Tooltip("徘徊位置の親オブジェクト")]
    [SerializeField] private Transform _wanders = default;
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private Transform _player = default;

    [SerializeField] private float _sqrValue = 2f;
    [SerializeField] private float _searchInterval = 1f;

    private float _timer = 0f;

    private void Awake()
    {
        if (_enemyPrefab && _wanders)
        {
            EnemySpawn();
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

    private void EnemySpawn()
    {
        for (int i = 0; i < _wanders.childCount; i++)
        {
            var go = Instantiate(_enemyPrefab, _wanders.GetChild(i).position, Quaternion.identity);

            go.transform.SetParent(transform);

            if (go.TryGetComponent(out EnemyController enemy))
            {
                enemy.Wandering = _wanders.GetChild(i).GetComponent<WanderingRange>();
                _enemies.Add(enemy);
            }
        }
    }

    private void SearchDitance()
    {
        if (_player)
        {
            foreach (var enemy in _enemies)
            {
                //一定距離以内で探索開始
                enemy.Wandering.IsMove
                    = (enemy.transform.position - _player.position).sqrMagnitude > _sqrValue;
            }
        }
    }
}
