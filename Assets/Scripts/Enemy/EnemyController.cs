using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health = new();
    [SerializeField] private EnemyMove _move = new();

    public EnemyHealth Health { get => _health; protected set => _health = value; }
    public EnemyMove Move { get => _move; protected set => _move = value; }

    private void Awake()
    {
        _health.Init();
        _move.Init();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _move.Update();
    }
}
