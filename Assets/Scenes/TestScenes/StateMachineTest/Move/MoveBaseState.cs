using UnityEngine;

namespace StateMachine
{
    /// <summary> 動き関連のステートの基底クラス </summary>
    public class MoveBaseState
    {
        private EnemyData _enemyData = default;
        private WanderingRange _wandering = default;
        private Transform _player = default;
        private Transform _enemy = default;
        private float _sqrDistance = 1f;

        public EnemyData EnemyData => _enemyData;
        public Transform Player => _player;
        public Transform Enemy => _enemy;

        public void Init(EnemyData enemyData, WanderingRange wandering, Transform player, Transform enemy, float sqrDistance)
        {
            _enemyData = enemyData;
            _wandering = wandering;
            _player = player;
            _enemy = enemy;
            _sqrDistance = sqrDistance;
        }
    }
}
