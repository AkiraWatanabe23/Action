using UnityEngine;

namespace StateMachine
{
    public class StateMachineRoot
    {
        private State _currentState = default;

        private BaseState _currentBaseState = default;

        public State CurrentState => _currentState;

        #region 各親ステート
        private IdleState _idle = new();
        private MoveBaseState _move = new();
        private ConductBaseState _conduct = new();

        public IdleState Idle => _idle;
        public MoveBaseState Move => _move;
        public ConductBaseState Conduct => _conduct;
        #endregion

        #region 各子ステート
        private SearchState _search = new();
        private ChaseState _chase = new();
        private EscapeState _escape = new();

        public SearchState Search => _search;
        public ChaseState Chase => _chase;
        public EscapeState Escape => _escape;


        private AttackState _attack = new();
        private DamageState _damage = new();
        private DeathState _death = new();

        public AttackState Attack => _attack;
        public DamageState Damage => _damage;
        public DeathState Death => _death;
        #endregion

        public void Init()
        {
            //ここで必要な値の初期化を行う

            //初期ステートの設定
            _currentState = _idle;
            _currentBaseState = BaseState.Idle;
        }

        public void Update()
        {
            _currentState.OnUpdate(this);
        }

        private State GetState(BaseState state)
        {
            switch (state)
            {
                case BaseState.Idle:    return _idle;
                case BaseState.Move:    return _move;
                case BaseState.Conduct: return _conduct;
            }
            Debug.LogError("No State");
            return null;
        }

        private State GetState(SubState state)
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

            _currentBaseState = nextState;
        }

        public void ChangeState(SubState nextState)
        {
            _currentState.OnExit(this);
            _currentState = GetState(nextState);
            _currentState.OnEnter(this);

            switch (nextState)
            {
                case SubState.Search:
                case SubState.Chase:
                case SubState.Escape:
                    _currentBaseState = BaseState.Move;
                    break;
                case SubState.Attack:
                case SubState.Damage:
                case SubState.Death:
                    _currentBaseState = BaseState.Conduct;
                    break;
            }
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
