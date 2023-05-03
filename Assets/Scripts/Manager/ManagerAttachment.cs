using UnityEngine;
using UnityEngine.UI;

public class ManagerAttachment : MonoBehaviour
{
    [Header("UI一覧(Debug)")]
    [SerializeField] private Text _timerText = default;
    [SerializeField] private Text _countText = default;

    [SerializeField] private int _spawnCount = 0;
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private GameObject _wanderingPositions = default;

    private GameManager _gameManager = default;
    private UIManager _uiManager = default;

    private void Awake()
    {
        var managers = GameObject.Find("Manager");

        _gameManager = managers.GetComponent<GameManager>();
        _uiManager = managers.GetComponent<UIManager>();

        _gameManager.SetGameStatus();
        _uiManager.SettingUI(_timerText, _countText);
    }

    private void Start()
    {
        _gameManager.Start();
        _gameManager.EnemySpawn(_spawnCount, _enemyPrefab, _wanderingPositions);
    }

    private void Update()
    {
        _uiManager.TimerText.text = _gameManager.Timer.ToString("F0");
    }
}
