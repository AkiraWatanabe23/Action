using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [Tooltip("武器の種類")]
    [SerializeField] private WeaponType _weapon = WeaponType.Sword;
    [SerializeField] private AttackType _attack = AttackType.Normal;

    private Transform _trans = default;
    private int _skillGauge = 0;
    private int _maxGauge = 50;
    /// <summary> 攻撃力 </summary>
    private int _attackValue = 10;

    public WeaponType Weapon { get => _weapon; set => _weapon = value; }
    public AttackType Attack { get => _attack; set => _attack = value; }
    public int SkillGauge { get => _skillGauge; set => _skillGauge = value; }
    public int MaxGauge { get => _maxGauge; protected set => _maxGauge = value; }

    public void Init(Transform trans)
    {
        _trans = trans;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(_trans.position, _trans.forward, Color.green, 10f);
            //攻撃(引数の値は仮)
            if (Physics.Raycast(_trans.position, _trans.forward, out RaycastHit hit, 20f))
            {
                if (hit.collider.gameObject.TryGetComponent(out EnemyController enemy))
                {
                    //この部分の参照をあとで修正
                    enemy.StateMachine.Damage.ReceiveDamege(_attackValue);
                    GaugeUp(_attackValue / 10);
                    Debug.Log("こうげき");
                }
            }
        }
    }

    /// <summary> 武器の切り替え </summary>
    public void SwitchWeapon()
    {
        var attack = _weapon;

        //パラメータの変更
        if (attack == WeaponType.Sword)
        {
            _weapon = WeaponType.Gun;
        }
        else if (attack == WeaponType.Gun)
        {
            _weapon = WeaponType.Sword;
        }
    }

    /// <summary> 自分の攻撃が当たった時に呼び出す </summary>
    private void GaugeUp(int value)
    {
        if (_skillGauge < _maxGauge)
        {
            _skillGauge += value;
            if (_skillGauge >= _maxGauge)
            {
                _skillGauge = _maxGauge;
            }
        }
        else
        {
            Debug.Log("ゲージは最大です");
        }
    }
}

/// <summary> 武器の種類 </summary>
public enum WeaponType
{
    Sword,
    Gun,
}

/// <summary> 攻撃の形式(通常か、スキルを使うか) </summary>
public enum AttackType
{
    Normal,
    Skill,
}
