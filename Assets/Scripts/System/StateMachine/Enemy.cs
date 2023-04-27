using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStateBase _currentState = default;

    private readonly SearchPlayer _search = new();
    private readonly Chase _chase = new();
    private readonly Attack _attack = new();
    private readonly Damage _damage = new();
    private readonly Dead _dead = new();

    private void Start()
    {
        _currentState = _search;
        _search.OnStart(this);
    }

    private void Update()
    {
        _currentState.OnUpdate(this);
    }

    private void SwitchState(EnemyStates nextState)
    {
        _currentState.OnExit(this);
        _currentState = GetState(nextState);
        _currentState.OnStart(this);
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

    private enum EnemyStates
    {
        Search,
        Chase,
        Attack,
        Damege,
        Dead,
    }
}
