using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private Text _textField = default;
    [SerializeField] private Button _button = default;

    private Presenter _presenter = default;

    private void Start()
    {
        _presenter = new(this);
        _button.onClick.AddListener(_presenter.OnButtonClick);
    }

    public void UpdateText(string text)
    {
        _textField.text = text;
    }
}
