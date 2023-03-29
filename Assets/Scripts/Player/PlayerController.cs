using Banzan.Lib.Utility;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Status")]
    [SerializeField] private PlayerMove _movement = new();
    [SerializeField] private PlayerHealth _health = new();
    [SerializeField] private PlayerAttack _attack = new();

    private CharacterController _controller = default;

    public PlayerMove Move { get => _movement; protected set => _movement = value; }
    public PlayerHealth Health { get => _health; protected set => _health = value; }
    public PlayerAttack Attack { get => _attack; protected set => _attack = value; }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _movement.Init(_controller, transform);
        _health.Init();
        _attack.Init(transform);
    }

    private void Update()
    {
        _movement.Update();
    }

    [EnumAction(typeof(AttackType))]
    public void SwitchWeapon(int type)
    {
        _attack.SwitchWeapon(type);
    }
}
