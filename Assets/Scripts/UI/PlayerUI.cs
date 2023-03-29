using UnityEngine;
using UnityEngine.UI;

/// <summary> PlayerのUIを管理する </summary>
public class PlayerUI : MonoBehaviour
{
    [Tooltip("0...HP, 1...Skill")]
    [SerializeField] private Slider[] _statusSlider = new Slider[2];
    [SerializeField] private Text[] _statusText = new Text[2];

    private PlayerController _player = default;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        //Sliderの初期設定
        _statusSlider[0].minValue = 0;
        _statusSlider[1].minValue = 0;

        _statusSlider[0].maxValue = _player.Health.MaxHp;
        _statusSlider[1].maxValue = _player.Attack.MaxGauge;

        _statusSlider[0].value = _player.Health.HP;
        _statusSlider[1].value = 0;
    }

    private void Update()
    {
        
    }
}
