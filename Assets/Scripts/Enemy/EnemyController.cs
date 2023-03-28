using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health = new();

    public EnemyHealth Health { get => _health; protected set => _health = value; }

    private void Awake()
    {
        _health.Init();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
