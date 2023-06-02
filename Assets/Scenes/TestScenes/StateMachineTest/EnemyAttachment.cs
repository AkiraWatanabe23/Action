using StateMachine;
using UnityEngine;

public class EnemyAttachment : MonoBehaviour
{
    private StateMachineRoot _root = new();

    public StateMachineRoot Root => _root;

    private void Start()
    {
        _root.Init();
    }

    private void Update()
    {
        _root.Update();
    }
}
