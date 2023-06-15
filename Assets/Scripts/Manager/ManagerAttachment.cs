using UnityEngine;
using UnityEngine.UI;

public class ManagerAttachment : MonoBehaviour
{
    [Header("UI一覧")]
    [SerializeField] private GameObject _menuPanel = default;
    [SerializeField] private Text _timerText = default;
    [SerializeField] private Text _countText = default;
    [SerializeField] private GameObject _resultPrefab = default;

    [SerializeField] private Text _resultText = default;

    private GameManager _gameManager = default;
    private UIManager _uiManager = default;

    private void Awake()
    {
        var managers = GameObject.Find("Manager");
        var enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        _gameManager = managers.GetComponent<GameManager>();
        _uiManager = managers.GetComponent<UIManager>();

        _uiManager.SettingUI(_menuPanel, _timerText, _countText, _resultText, _resultPrefab);
        _gameManager.SetGameStatus(_uiManager, enemyManager);
    }

    private void Start()
    {
        if (_gameManager.IsGameStart)
        {
            _gameManager.Start();
        }
    }
}
