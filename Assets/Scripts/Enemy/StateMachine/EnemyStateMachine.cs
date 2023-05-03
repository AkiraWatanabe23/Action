using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyStateMachine
{
    [Header("State一覧")]
    [SerializeField] private SearchPlayer _search = new();
    [SerializeField] private Chase _chase = new();
    [SerializeField] private Attack _attack = new();
    [SerializeField] private Damage _damage = new();
    [SerializeField] private Dead _dead = new();

    private EnemyStateBase _currentState = default;

    public void InitStatus(
        EnemyData data, NavMeshAgent agent, WanderingRange wandering, GameObject player, GameObject enemy, float distance, int hp)
    {
        //各値の初期化
        _search.Init(data, agent, wandering, player, enemy, distance);
        _chase.Init(agent, wandering, player, enemy);
        _attack.Init(data, enemy);
        _damage.Init();

        //初期ステートを設定、実行
        _currentState = _search;
        _search.OnStart(this);
    }

    public void Update()
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
