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
    private Animator _anim = default;
    private int _hp = 100;
    private float _sqrDistance = 1f;

    public EnemyData Data => _data;
    public WanderingRange Wandering => _wandering;
    public EnemyStateMachine StateMachine => _stateMachine;

    private void Start()
    {
        //初期設定
        _agent = GetComponent<NavMeshAgent>();
        //_anim = GetComponent<Animator>();

        _agent.speed = _data.MoveSpeed;
        _hp = _data.MaxHP;
        _sqrDistance = _data.SearchDistance * _data.SearchDistance;

        _stateMachine.InitStatus(
            _data, _agent, _wandering, _player, gameObject, _sqrDistance, _hp);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void ReceiveDamege(int value)
    {
        _hp -= value;
        //フラグを立て、ステートを切り替える
    }
}
