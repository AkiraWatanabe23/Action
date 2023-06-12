using UnityEngine;

[System.Serializable]
public class PlayerHealth : IDamage
{
    [SerializeField] private int _hp = 100;

    private int _maxHp = 100;
    private PlayerAnimation _anim = default;

    public int HP { get => _hp; set => _hp = value; }
    public int MaxHp { get => _maxHp; protected set => _maxHp = value; }

    public void Init(PlayerAnimation anim)
    {
        _anim = anim;
    }

    public void ReceiveDamege(int value)
    {
        _hp -= value;
        _anim.ChangeAnimToDamage();

        if (_hp <= 0)
        {
            //‚â‚ç‚ê‚½
            _anim.ChangeAnimToDeath();
            return;
        }
    }
}
