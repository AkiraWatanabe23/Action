using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _data = default;
    [Tooltip("シーン上のPlayer(アタッチしてください)")]
    [SerializeField] private GameObject _player = default;
    [SerializeField] private WanderingRange _wandering = default;

    [SerializeField] private SearchPlayer _search = new();
    [SerializeField] private Chase _chase = new();
    [SerializeField] private Attack _attack = new();
    [SerializeField] private Damage _damage = new();
    [SerializeField] private Dead _dead = new();

    private EnemyStateBase _currentState = default;
    private NavMeshAgent _agent = default;

    private float _sqrDistance = 0f;

    public EnemyData Data => _data;
    public WanderingRange Wandering => _wandering;
    public GameObject Player => _player;
    public NavMeshAgent Agent => _agent;
    public float SqrDistance => _sqrDistance;

    private void Start()
    {
        //初期設定
        _agent = GetComponent<NavMeshAgent>();

        _sqrDistance = _data.SearchDistance * _data.SearchDistance;

        //初期ステートを設定
        _currentState = _search;
        _search.OnStart(this);
    }

    private void Update()
    {
        _currentState.OnUpdate(this);
    }

    private EnemyStateBase GetState(EnemyStates state)
    {
        switch (state)
        {
            case EnemyStates.Search:
                return _search;
            case EnemyStates.Chase:
                return _chase;
            case EnemyStates.Attack:
                return _attack;
            case EnemyStates.Damege:
                return _damage;
            case EnemyStates.Dead:
                return _dead;
        }

        Debug.LogWarning("no state");
        return null;
    }

    public void SwitchState(EnemyStates nextState)
    {
        _currentState.OnExit(this);
        _currentState = GetState(nextState);
        _currentState.OnStart(this);
    }

    public enum EnemyStates
    {
        Search,
        Chase,
        Attack,
        Damege,
        Dead,
    }
}
