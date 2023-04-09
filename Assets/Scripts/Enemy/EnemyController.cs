using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health = new();
    [SerializeField] private EnemyMove _move = new();

    private NavMeshAgent _agent = default;

    public EnemyHealth Health { get => _health; protected set => _health = value; }
    public EnemyMove Move { get => _move; protected set => _move = value; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _health.Init();
        _move.Init(_agent);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _move.Update();
    }
}
