using UnityEngine;
using UnityEngine.AI;

namespace StateMachine
{
    [System.Serializable]
    public class StateMachineRoot
    {
        private IState _currentState = default;

        public IState CurrentState => _currentState;

        #region 各親ステート
        [SerializeField] private IdleState _idle = new();
        [SerializeField] private MoveBaseState _move = new();
        [SerializeField] private ConductBaseState _conduct = new();

        public IdleState Idle => _idle;
        public MoveBaseState Move => _move;
        public ConductBaseState Conduct => _conduct;
        #endregion

        #region 各子ステート
        [SerializeField] private SearchState _search = new();
        [SerializeField] private ChaseState _chase = new();
        [SerializeField] private EscapeState _escape = new();

        public SearchState Search => _search;
        public ChaseState Chase => _chase;
        public EscapeState Escape => _escape;


        [SerializeField] private AttackState _attack = new();
        [SerializeField] private DamageState _damage = new();
        [SerializeField] private DeathState _death = new();

        public AttackState Attack => _attack;
        public DamageState Damage => _damage;
        public DeathState Death => _death;
        #endregion

        public void Init(EnemyData enemyData, WanderingRange wandering, NavMeshAgent agent,
                         Transform player, Transform enemy, float distance,
                         Animator anim)
        {
            //ここで必要な値の初期化を行う
            _idle.Init();
            _move.Init(enemyData, wandering, agent, player, enemy, distance, anim);
            _conduct.Init();

            //初期ステートの設定
            _currentState = _idle;
        }

        public void Update()
        {
            _currentState.OnUpdate(this);
        }

        private IState GetState(BaseState state)
        {
            switch (state)
            {
                case BaseState.Idle:    return _idle;
                //case BaseState.Move:    return _move;
                //case BaseState.Conduct: return _conduct;
            }
            Debug.LogError("No State");
            return null;
        }

        private IState GetState(SubState state)
        {
            switch (state)
            {
                case SubState.Search: return _search;
                case SubState.Chase:  return _chase;
                case SubState.Escape: return _escape;
                case SubState.Attack: return _attack;
                case SubState.Damage: return _damage;
                case SubState.Death:  return _death;
            }
            Debug.LogError("No State");
            return null;
        }

        public void ChangeState(BaseState nextState)
        {
            _currentState.OnExit(this);
            _currentState = GetState(nextState);
            _currentState.OnEnter(this);
        }

        public void ChangeState(SubState nextState)
        {
            _currentState.OnExit(this);
            _currentState = GetState(nextState);
            _currentState.OnEnter(this);
        }

        public enum BaseState
        {
            Idle,
            Move,
            Conduct
        }

        public enum SubState
        {
            //MoveのSubState
            Search,
            Chase,
            Escape,
            //ConductのSubState
            Attack,
            Damage,
            Death,
        }
    }
}
