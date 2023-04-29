using UnityEngine;
using UnityEngine.UI;

/// <summary> EnemyのUIを管理する
///           注意点：EnemyCanvasの設定を「RenderMode...WorldSpace」に変更 </summary>
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider = default;

    private Canvas _enemyCanvas = default;
    private Enemy _enemy = default;

    private void Awake()
    {
        var enemy = transform.parent.gameObject;

        _enemy = enemy.GetComponent<Enemy>();
        _enemyCanvas = enemy.GetComponentInChildren<Canvas>();

        //EnemyのUIがワールド座標上に表示されるようにする
        _enemyCanvas.renderMode = RenderMode.WorldSpace;
    }

    private void Start()
    {
        //Sliderの初期設定
        _hpSlider.minValue = 0;
    }

    private void Update()
    {
        if (_enemy.Wandering.IsMove)
        {
            _enemyCanvas.gameObject.SetActive(true);
        }
        else
        {
            _enemyCanvas.gameObject.SetActive(false);
        }
    }
}
