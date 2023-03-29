using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //0...HP, 1...Skill
    [SerializeField] private Slider[] _playerStatus = new Slider[2];

    private PlayerController _player = default;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        //Sliderの初期設定
        _playerStatus[0].minValue = 0;
        _playerStatus[1].minValue = 0;

        _playerStatus[0].maxValue = _player.Health.MaxHp;
        _playerStatus[1].maxValue = _player.Attack.MaxGauge;

        _playerStatus[1].value = 0;
    }

    private void Update()
    {
        
    }
}
