using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Status")]
    [SerializeField] private PlayerMove _movement = new();
    [SerializeField] private PlayerHealth _health = new();
    [SerializeField] private PlayerAttack _attack = new();
    [SerializeField] private PlayerAnimation _animation = new();

    private CharacterController _controller = default;
    private Rigidbody _rb = default;
    private Animator _anim = default;

    public PlayerMove Move { get => _movement; protected set => _movement = value; }
    public PlayerHealth Health { get => _health; protected set => _health = value; }
    public PlayerAttack Attack { get => _attack; protected set => _attack = value; }
    public PlayerAnimation Animation { get => _animation; protected set => _animation = value; }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
        //_anim = GetComponent<Animator>();

        if (_movement.MoveType == MoveType.Chara)
        {
            _movement.Init(_controller, transform);
        }
        else if (_movement.MoveType == MoveType.Rigid)
        {
            _movement.Init(transform, _rb);
        }
        _health.Init();
        _attack.Init(transform);
        //_animation.Init(_anim);
    }

    private void Update()
    {
        if (_movement.MoveType == MoveType.Chara)
        {
            _movement.Update();
        }
        _attack.Update();
    }

    private void FixedUpdate()
    {
        if (_movement.MoveType == MoveType.Rigid)
        {
            _movement.FixedUpdate();
        }
    }

    public void SwitchWeapon()
    {
        _attack.SwitchWeapon();
    }
}
