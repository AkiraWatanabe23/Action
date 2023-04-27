using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStates _currentState = EnemyStates.Idle;

    private EnemyStates _nextState = EnemyStates.Idle;

    private readonly Idle _idle = new();
    private readonly Move _move = new();
    private readonly Attack _attack = new();
    private readonly Damage _damage = new();
    private readonly Dead _dead = new();

    private void Start()
    {
        _idle.OnStart();
    }

    private void Update()
    {
        //各ステートのUpdate処理
        switch (_currentState)
        {
            case EnemyStates.Idle:
                _idle.OnUpdate();
                break;
            case EnemyStates.Move:
                _move.OnUpdate();
                break;
            case EnemyStates.Chase:
                break;
            case EnemyStates.Attack:
                _attack.OnUpdate();
                break;
            case EnemyStates.Damege:
                _damage.OnUpdate();
                break;
            case EnemyStates.Dead:
                _dead.OnUpdate();
                break;
        }

        //ステート切り替え時
        if (_currentState != _nextState)
        {
            //終了処理
            switch (_currentState)
            {
                case EnemyStates.Idle:
                    _idle.OnExit();
                    break;
                case EnemyStates.Move:
                    _move.OnExit();
                    break;
                case EnemyStates.Chase:
                    break;
                case EnemyStates.Attack:
                    _attack.OnExit();
                    break;
                case EnemyStates.Damege:
                    _damage.OnExit();
                    break;
                case EnemyStates.Dead:
                    _dead.OnExit();
                    break;
            }
        }

        //ステートを遷移→遷移先のステートのstart処理
        _currentState = _nextState;
        switch (_currentState)
        {
            case EnemyStates.Idle:
                _idle.OnStart();
                break;
            case EnemyStates.Move:
                _move.OnStart();
                break;
            case EnemyStates.Chase:
                break;
            case EnemyStates.Attack:
                _attack.OnStart();
                break;
            case EnemyStates.Damege:
                _damage.OnStart();
                break;
            case EnemyStates.Dead:
                _dead.OnStart();
                break;
        }
    }

    private void SwitchState(EnemyStates state)
    {
        _nextState = state;
    }

    private enum EnemyStates
    {
        Idle,
        Move,
        Chase,
        Attack,
        Damege,
        Dead,
    }
}
