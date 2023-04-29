using UnityEngine;
using UnityEngine.UI;

/// <summary> EnemyのUIを管理する </summary>
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

    private void OnEnable()
    {
        _enemy.Wandering.SetCanvas += CanvasSetting;
    }

    private void OnDisable()
    {
        _enemy.Wandering.SetCanvas -= CanvasSetting;
    }

    private void Start()
    {
        //Sliderの初期設定
        _hpSlider.minValue = 0;
        //maxValueの設定
    }

    private void Update()
    {

    }

    /// <summary> 徘徊中のみCanvasを表示する </summary>
    public void CanvasSetting(bool set)
    {
        _enemyCanvas.gameObject.SetActive(set);
    }
}
