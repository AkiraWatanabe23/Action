using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Status")]
    [SerializeField] private PlayerMove _movement = new();
    [SerializeField] private PlayerHealth _health = new();
    [SerializeField] private PlayerAttack _attack = new();
    [SerializeField] private PlayerAnimation _animation = new();

    private CharacterController _controller = default;
    private Animator _anim = default;

    public PlayerMove Move { get => _movement; protected set => _movement = value; }
    public PlayerHealth Health { get => _health; protected set => _health = value; }
    public PlayerAttack Attack { get => _attack; protected set => _attack = value; }
    public PlayerAnimation Animation { get => _animation; protected set => _animation = value; }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        //_anim = GetComponent<Animator>();

        _movement.Init(_controller, transform);
        _health.Init();
        _attack.Init(transform);
        //_animation.Init(_anim);
    }

    private void Update()
    {
        _movement.Update();
    }

    public void SwitchWeapon()
    {
        _attack.SwitchWeapon();
    }
}
