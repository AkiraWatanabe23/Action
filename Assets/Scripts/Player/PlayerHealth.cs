using UnityEngine;

[System.Serializable]
public class PlayerHealth : IDamage
{
    [SerializeField] private int _hp = 100;

    private int _maxHp = 100;
    private PlayerAnimation _animation = default;

    public int HP { get => _hp; set => _hp = value; }
    public int MaxHp { get => _maxHp; protected set => _maxHp = value; }

    public void Init(PlayerAnimation animation)
    {
        _animation = animation;
    }

    public void ReceiveDamege(int value)
    {
        _hp -= value;

        if (_hp <= 0)
        {
            //‚â‚ç‚ê‚½
            return;
        }
    }
}
