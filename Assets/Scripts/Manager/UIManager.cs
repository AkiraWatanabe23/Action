using UnityEngine;
using UnityEngine.UI;

/// <summary> ゲーム全体に関わるUIを管理する </summary>
public class UIManager : MonoBehaviour
{
    private Text _timerText = default;
    private Text _countText = default;

    public Text TimerText { get => _timerText; set => _timerText = value; }
    public Text CountText { get => _countText; set => _countText = value; }
    
    private void Start()
    {

    }

    private void Update()
    {
        
    }

    /// <summary> UI初期設定 </summary>
    public void SettingUI(Text timer, Text count)
    {
        _timerText = timer;
        _countText = count;
    }
}
