using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Image _titlePanel = default;
    [SerializeField] private Button _startButton = default;

    private bool _isGameStart = false;

    public bool IsGameStart => _isGameStart;

    private void Start()
    {
        _titlePanel.enabled = true;
        _startButton.onClick.AddListener(() =>
        {
            _titlePanel.enabled = false;
            _isGameStart = true;
        });
    }
}
