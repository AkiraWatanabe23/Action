using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour, IDamage
{
    [SerializeField] private EnemyData _data = default;
    [SerializeField] private WanderingRange _wandering = default;
    [SerializeField] private EnemyStateMachine _stateMachine = new();
    [SerializeField] private int _hp = 100;

    private Transform _player = default;
    private NavMeshAgent _agent = default;
    //private Animator _anim = default;
    private float _sqrDistance = 1f;

    public EnemyData Data => _data;
    public WanderingRange Wandering { get => _wandering; set => _wandering = value; }
    public int HP { get => _hp; set => _hp = value; }
    public Transform Player { get => _player; set => _player = value; }

    private void Start()
    {
        //初期設定
        _agent = GetComponent<NavMeshAgent>();
        //_anim = GetComponent<Animator>();

        _agent.speed = _data.MoveSpeed;
        _hp = _data.MaxHP;
        _sqrDistance = _data.SearchDistance * _data.SearchDistance;

        _stateMachine.InitStatus(
            _data, _agent, _wandering, _player, transform, _sqrDistance, _hp);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void ReceiveDamege(int value)
    {
        _hp -= value;

        if (_hp <= 0)
        {
            //やられた
            _stateMachine.SwitchState(EnemyStateMachine.EnemyStates.Dead);
        }
        else
        {
            _stateMachine.SwitchState(EnemyStateMachine.EnemyStates.Damege);
        }
    }
}
