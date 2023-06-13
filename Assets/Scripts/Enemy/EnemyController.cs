using StateMachine;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour, IDamage
{
    [SerializeField] private EnemyData _enemyData = default;
    [SerializeField] private StateMachineRoot _stateMachine = new();

    private WanderingRange _wandering = default;
    private NavMeshAgent _agent = default;
    private Animator _anim = default;

    private int _hp = 100;
    private float _sqrDistance = 1f;
    private Transform _player = default;

    public EnemyData EnemyData => _enemyData;
    public StateMachineRoot StateMachine => _stateMachine;
    public WanderingRange Wandering { get => _wandering; set => _wandering = value; }
    public int HP { get => _hp; set => _hp = value; }
    public Transform Player { get => _player; set => _player = value; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _hp = _enemyData.MaxHP;
        _sqrDistance = Mathf.Pow(_enemyData.SearchDistance, 2);

        _stateMachine.Init(_enemyData, _wandering, _agent, _player, transform, _sqrDistance, _anim);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void ReceiveDamege(int value)
    {
        _hp -= value;
        //HPの残り具合で遷移するステートを変更
        if (_hp <= 0)
        {
            _stateMachine.ChangeState(StateMachineRoot.SubState.Death);
        }
        else if (_hp <= (int)(_enemyData.MaxHP * _stateMachine.Damage.EscapeValue))
        {
            _stateMachine.ChangeState(StateMachineRoot.SubState.Escape);
        }
        else
        {
            _stateMachine.ChangeState(StateMachineRoot.SubState.Damage);
        }
    }
}
