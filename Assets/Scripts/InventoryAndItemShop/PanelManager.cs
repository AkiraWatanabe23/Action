using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _closepanel;
    PlayerController _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }
    public void Close()
    {
        _panel.SetActive(false);
        //_player._playerState = Player.state.Wandering;
    }
    public void Open()
    {
        _panel.SetActive(true);
    }
    public void OpenAndClose()
    {
        _panel.SetActive(true);
        _closepanel.SetActive(false);
    }
    public void CloseAndOpen()
    {
        _panel.SetActive(false);
        _closepanel.SetActive(true);
    }
}
