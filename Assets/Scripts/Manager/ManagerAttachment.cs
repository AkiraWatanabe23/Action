using UnityEngine;
using UnityEngine.UI;

public class ManagerAttachment : MonoBehaviour
{
    [Header("UI一覧")]
    [SerializeField] private GameObject _menuPanel = default;
    [SerializeField] private Text _timerText = default;
    [SerializeField] private Text _countText = default;

    private GameManager _gameManager = default;
    private UIManager _uiManager = default;

    private void Awake()
    {
        var managers = GameObject.Find("Manager");

        _gameManager = managers.GetComponent<GameManager>();
        _uiManager = managers.GetComponent<UIManager>();

        _gameManager.SetGameStatus();
        _uiManager.SettingUI(_menuPanel, _timerText, _countText);
    }

    private void Start()
    {
        if (_gameManager.IsGameStart)
        {
            _gameManager.Start();
        }
    }

    private void Update()
    {
        _uiManager.TimerText.text = _gameManager.Timer.ToString("F0");
        _uiManager.CountText.text = $"{ _gameManager.KillCount }  /  { _gameManager.MaxKillCount }";
    }
}
