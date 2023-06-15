using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//アイテムショップに並ぶアイテムの配列
public class ShopDataBase : MonoBehaviour
{
    [Header("作ったアイテムを格納するリスト")] public List<ItemObj> _itemObjs = new();

    [SerializeField] private Text _discription = default;
    [SerializeField] private Image _image = default;

    public Text Discription { get => _discription; set => _discription = value; }
    public Image Image { get => _image; set => _image = value; }
}

