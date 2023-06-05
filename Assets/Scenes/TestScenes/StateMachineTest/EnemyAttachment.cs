using StateMachine;
using UnityEngine;

public class EnemyAttachment : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData = default;

    private readonly StateMachineRoot _root = new();

    private int _hp = 100;
    private float _sqrDistance = 1f;
    private Transform _player = default;

    private WanderingRange _wandering = default;

    public StateMachineRoot Root => _root;
    public int HP { get => _hp; set => _hp = value; }
    public float SqrDistance => _sqrDistance;
    public Transform Player => _player;
    public WanderingRange Wandering { get => _wandering; set => _wandering = value; }

    private void Start()
    {
        _hp = _enemyData.MaxHP;
        _sqrDistance = Mathf.Pow(_enemyData.SearchDistance, 2);

        _root.Init(_enemyData, _wandering, _player, transform, _sqrDistance);
    }

    private void Update()
    {
        _root.Update();
    }
}
