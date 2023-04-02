using Banzan.Lib.Utility;
using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [Tooltip("武器の種類")]
    [SerializeField] private AttackType _type = AttackType.Sword;

    private Transform _trans = default;
    private int _skillGauge = 0;
    private int _maxGauge = 50;
    /// <summary> 攻撃力 </summary>
    private int _attackValue = 10;

    public AttackType Type { get => _type; set => _type = value; }
    public int SkillGauge { get => _skillGauge; set => _skillGauge = value; }
    public int MaxGauge { get => _maxGauge; protected set => _maxGauge = value; }

    public void Init(Transform trans)
    {
        _trans = trans;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawRay(_trans.position, _trans.forward, Color.green, 10f);
            //攻撃
            if (Physics.Raycast(_trans.position, _trans.forward, out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out EnemyController enemy))
                {
                    enemy.Health.ReceiveDamege(_attackValue);
                    GaugeUp(_attackValue / 10);
                    Debug.Log("こうげき");
                }
            }
        }
    }

    /// <summary> 武器の切り替え </summary>
    [EnumAction(typeof(AttackType))]
    public void SwitchWeapon(int type)
    {
        var attack = (AttackType)type;

        //パラメータの変更
        if (attack == AttackType.Sword)
        {
            _type = AttackType.Sword;
        }
        else if (attack == AttackType.Gun)
        {
            _type = AttackType.Gun;
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
            Debug.Log("ゲージが溜まりました");
        }
    }
}

public enum AttackType
{
    Sword,
    Gun,
}
