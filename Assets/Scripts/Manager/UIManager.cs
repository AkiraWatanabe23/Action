using UnityEngine;
using UnityEngine.UI;

/// <summary> ゲーム全体に関わるUIを管理する </summary>
public class UIManager : MonoBehaviour
{
    private bool _isOpenMenu = false;

    private GameObject _menuPanel = default;
    private Text _timerText = default;
    private Text _countText = default;

    public Text TimerText { get => _timerText; set => _timerText = value; }
    public Text CountText { get => _countText; set => _countText = value; }

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
    }

    /// <summary> UI初期設定 </summary>
    public void SettingUI(GameObject panel, Text timer, Text count)
    {
        _menuPanel = panel;
        _timerText = timer;
        _countText = count;
    }
}
