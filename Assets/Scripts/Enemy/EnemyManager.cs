using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<EnemyController> _enemies = new();

    [Tooltip("徘徊位置の親オブジェクト")]
    [SerializeField] private Transform _wanderingPositions = default;
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private Transform _player = default;

    [Header("Enemyが探索を行う際の値")]
    [SerializeField] private float _sqrValue = 2f;
    [SerializeField] private float _searchInterval = 0.5f;

    private float _timer = 0f;

    private void Awake()
    {
        if (_enemyPrefab && _wanderingPositions)
        {
            EnemySpawn();
        }

        if (_player)
        {
            //Playerの参照の取得
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

    /// <summary> 敵の生成 </summary>
    private void EnemySpawn()
    {
        for (int i = 0; i < _wanderingPositions.childCount; i++)
        {
            var go = Instantiate(_enemyPrefab, _wanderingPositions.GetChild(i).position, Quaternion.identity);

            go.transform.SetParent(transform);

            if (go.TryGetComponent(out EnemyController enemy))
            {
                enemy.Wandering = _wanderingPositions.GetChild(i).GetComponent<WanderingRange>();
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
