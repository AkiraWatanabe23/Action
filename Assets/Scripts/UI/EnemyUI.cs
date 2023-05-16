using UnityEngine;
using UnityEngine.UI;

/// <summary> EnemyのUIを管理する </summary>
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider = default;

    private Canvas _enemyCanvas = default;
    private EnemyController _enemy = default;

    private void Awake()
    {
        var enemy = transform.parent.gameObject;

        _enemy = enemy.GetComponent<EnemyController>();
        _enemyCanvas = enemy.GetComponentInChildren<Canvas>();

        //EnemyのUIがワールド座標上に表示されるようにする
        _enemyCanvas.renderMode = RenderMode.WorldSpace;
    }

    private void Start()
    {
        //Sliderの初期設定
        _hpSlider.minValue = 0;
        _hpSlider.maxValue = _enemy.Data.MaxHP;
        _hpSlider.value = _enemy.HP;
    }

    private void Update()
    {
        _hpSlider.value = _enemy.HP;
    }
}
