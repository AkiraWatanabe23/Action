using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Range(1, 30)]
    [Tooltip("1ユニットあたりの敵の数")]
    [SerializeField] private int _members = 1;
    [SerializeField] private List<EnemyController> _enemies = new();

    [Tooltip("徘徊位置の親オブジェクト")]
    [SerializeField] private Transform _wanderingPositions = default;
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private Transform _player = default;

    [Header("Enemyが探索を行う際の値")]
    [SerializeField] private float _sqrValue = 2f;
    [SerializeField] private float _searchInterval = 0.5f;

    private float _timer = 0f;
    private WanderingRange[] _wanders = default;

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

    /// <summary> 敵の生成
    ///           （徘徊範囲内のランダムな場所に生成する）</summary>
    private void EnemySpawn()
    {
        int unitCount = _wanderingPositions.childCount;
        _wanders = new WanderingRange[unitCount];

        for (int i = 0; i < unitCount; i++)
        {
            _wanders[i] = _wanderingPositions.GetChild(i).GetComponent<WanderingRange>();
            var wander = _wanders[i];

            var rangeEnemies = wander.gameObject.GetComponent<EnemyRange>().Enemies;

            for (int j = 0; j < _members; j++)
            {
                var circlePos = wander.Radius * Random.insideUnitCircle;
                var spawnPos = new Vector3(circlePos.x, 3f, circlePos.y) + wander.gameObject.transform.position;

                var go = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
                go.transform.SetParent(transform);

                if (go.TryGetComponent(out EnemyController enemy))
                {
                    _enemies.Add(enemy);
                    enemy.Wandering = wander;
                    rangeEnemies.Add(enemy);
                }
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
