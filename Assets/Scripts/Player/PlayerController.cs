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
    private Animator _anim = default;

    private int _gold = 100000;

    public PlayerHealth Health { get => _health; protected set => _health = value; }
    public PlayerAttack Attack { get => _attack; protected set => _attack = value; }
    public int Gold { get => _gold; set => _gold = value; }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _anim = transform.GetChild(0).GetComponent<Animator>();

        _movement.Init(_controller, transform, _animation);
        _health.Init(_animation);
        _attack.Init(transform, _animation);
        _animation.Init(_anim, _movement);
    }

    private void Update()
    {
        _movement.Update();
        _attack.Update();
    }

    public void SwitchWeapon()
    {
        _attack.SwitchWeapon();
    }

    private void OnDrawGizmosSelected()
    {
        //_movement.Overlap.OnDrawGizmos(transform);
    }
}
