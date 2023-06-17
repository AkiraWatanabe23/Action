using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [SerializeField] private Vector3 _offset = Vector3.zero;
    [SerializeField] private Vector3 _halfExtents = Vector3.zero;

    private Transform _transform = default;
    private PlayerAnimation _animation = default;

    private int _skillGauge = 0;
    private int _maxGauge = 50;
    private int _attackValue = 10;

    public int SkillGauge => _skillGauge;
    public int MaxGauge => _maxGauge;
    public int AttackValue { get => _attackValue; set => _attackValue = value; }

    public void Init(Transform trans, PlayerAnimation animation)
    {
        _transform = trans;
        _animation = animation;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _animation.ChangeAnimToAttack();
            
            if (Physics.BoxCast(
                _transform.position + _offset, _halfExtents, _transform.forward,
                out RaycastHit hit, Quaternion.identity, 20f))
            {
                if (hit.collider./*transform.parent.*/gameObject.TryGetComponent(out EnemyController enemy))
                {
                    enemy.ReceiveDamege(_attackValue);
                    GaugeUp(_attackValue / 10);
                    Debug.Log("こうげき");
                }
            }
            //_animation.ChangeAnimToIdle();
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
