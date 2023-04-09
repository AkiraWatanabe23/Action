using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyMove
{
    [SerializeField] private MoveType _type = MoveType.Normal;
    [SerializeField] private EnemyState _state = EnemyState.Wait;

    private NavMeshAgent _agent = default;
    private float _dist = 1f;
    private bool _isRunning = false;

    public void Init(NavMeshAgent agent)
    {
        _agent = agent;

        _dist = _agent.stoppingDistance;
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
    }

    private void Attack()
    {
        //攻撃
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
