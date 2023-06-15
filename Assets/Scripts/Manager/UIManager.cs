using UnityEngine;
using UnityEngine.UI;

/// <summary> ゲーム全体に関わるUIを管理する </summary>
public class UIManager : MonoBehaviour
{
    private bool _isOpenMenu = false;

    private GameObject _menuPanel = default;
    private Text _timerText = default;
    private Text _countText = default;
    private Text _resultText = default;
    private GameObject _resultPrefab = default;

    public Text TimerText { get => _timerText; set => _timerText = value; }
    public Text CountText { get => _countText; set => _countText = value; }
    public Text ResultText { get => _resultText; set => _resultText = value; }
    public GameObject ResultPrefab { get => _resultPrefab; set => _resultPrefab = value; }

    private void Start()
    {
        _menuPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isOpenMenu = !_isOpenMenu;
            _menuPanel.gameObject.SetActive(_isOpenMenu);
        }

        if (_resultText.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Fade.Instance.StartFadeOut();
            }
        }
    }

    /// <summary> UI初期設定 </summary>
    public void SettingUI(GameObject panel, Text timer, Text count, Text result, GameObject resultPrefab)
    {
        _menuPanel = panel;
        _timerText = timer;
        _countText = count;
        _resultText = result;
        _resultPrefab = resultPrefab;
    }
}
