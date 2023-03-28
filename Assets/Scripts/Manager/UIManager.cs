using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider[] _player = new Slider[2];

    private void Start()
    {
        _player[0].minValue = 0;
        _player[1].minValue = 0;
    }

    private void Update()
    {
        
    }
}
