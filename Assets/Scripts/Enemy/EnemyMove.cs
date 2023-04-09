using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyMove
{
    [SerializeField] private Transform _muzzle = default;
    [Range(1f, 30f)]
    [SerializeField] private float _raycastDistance = 1f;
    [SerializeField] private int _attackValue = 10;
    [SerializeField] private MoveType _type = MoveType.Normal;
    [SerializeField] private EnemyState _state = EnemyState.Wait;

    private NavMeshAgent _agent = default;
    private float _attackInterval = 5f;
    private float _attackTimer = 0f;
    private bool _isRunning = false;

    public void Init(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void Update()
    {
        SettingState();

        switch (_state)
        {
            case EnemyState.Wait:
                Wait();
                break;
            case EnemyState.Search:
                Search();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    private void SettingState()
    {
        if (_isRunning)
        {
            //ステートを実行中だったら何もしない
            return;
        }


    }

    private void Wait()
    {
        //その場で待機(動かずにPlayerを探す)
    }

    private void Search()
    {
        //Playerを探索(ステージを移動)
    }

    private void Chase()
    {
        //Playerを追従

        //追跡中に一定時間経ったら攻撃
        _attackTimer += Time.deltaTime;
        if (_attackTimer > _attackInterval)
        {
            _state = EnemyState.Attack;
            _attackTimer = 0f;
        }
    }

    private void Attack()
    {
        //攻撃
        if (Physics.Raycast(_muzzle.position, _muzzle.forward, out RaycastHit hit, _raycastDistance))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerController player))
            {
                player.Health.ReceiveDamege(_attackValue);
            }
        }

        _isRunning = false;
    }
}

public enum MoveType
{
    Normal,
    Boss,
}

public enum EnemyState
{
    Wait,
    Search,
    Chase,
    Attack,
}
