using StateMachine;
using UnityEngine;

public class EnemyAttachment : MonoBehaviour
{
    private StateMachineRoot _root = new();

    private Transform _player = default;

    public StateMachineRoot Root => _root;

    private void Start()
    {
        _root.Init(_player);
    }

    private void Update()
    {
        _root.Update();
    }
}
