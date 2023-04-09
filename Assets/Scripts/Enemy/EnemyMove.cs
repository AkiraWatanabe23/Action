using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyMove
{
    [SerializeField] private MoveType _type = MoveType.Normal;
    [SerializeField] private EnemyState _state = EnemyState.Wait;

    private NavMeshAgent _agent = default;

    public void Init(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void Update()
    {
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

    private void Wait()
    {
        //その場で待機
    }

    private void Search()
    {
        //Playerを探索
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
