using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] GameObject _inventoryLis;
    public Dictionary<int, Button> _buttonDic;
    public void Start()
    {
        _buttonDic = new Dictionary<int, Button>();
    }
}

