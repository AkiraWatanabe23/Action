using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Status")]
    [SerializeField] private PlayerMove _movement = new();
    [SerializeField] private PlayerHealth _health = new();

    private CharacterController _controller = default;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _movement.Init(_controller, transform);
        _health.Init();
    }

    private void Update()
    {
        _movement.Update();
    }
}
