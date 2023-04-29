using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour, IDamage
{
    [SerializeField] private EnemyData _data = default;
    [Tooltip("シーン上のPlayer(アタッチしてください)")]
    [SerializeField] private GameObject _player = default;
    [SerializeField] private WanderingRange _wandering = default;
    [SerializeField] private EnemyStateMachine _stateMachine = new();

    private NavMeshAgent _agent = default;

    private float _sqrDistance = 1f;

    public EnemyData Data => _data;
    public GameObject Player => _player;
    public WanderingRange Wandering => _wandering;
    public NavMeshAgent Agent => _agent;
    public float SqrDistance => _sqrDistance;

    private void Start()
    {
        //初期設定
        _agent = GetComponent<NavMeshAgent>();

        _sqrDistance = _data.SearchDistance * _data.SearchDistance;

        _stateMachine.InitStatus();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void ReceiveDamege(int value)
    {
        _data.HP -= value;
    }
}
