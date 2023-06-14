using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] private KeyCode _startKey = KeyCode.Return;
    [SerializeField] private Image _explainPanel = default;
    [SerializeField] private Text _countDownText = default;

    [SerializeField] private UnityEvent _onGameStart = default;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(_startKey))
        {
            ViewPanel();
        }
    }

    public void ViewPanel()
    {
        _explainPanel.gameObject.SetActive(true);
        StartCoroutine(StartCount());
    }

    private IEnumerator StartCount()
    {
        _countDownText.text = "";

        for (int i = 5; i >= 0; i--)
        {
            if (i > 0) _countDownText.text = i.ToString();
            else _countDownText.text = "Start!!";

            yield return new WaitForSeconds(1);
        }

        _onGameStart?.Invoke();
        gameObject.SetActive(false);
    }
}
