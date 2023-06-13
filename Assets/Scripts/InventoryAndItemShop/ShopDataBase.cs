using System.Collections.Generic;
using UnityEngine;
//アイテムショップに並ぶアイテムの配列
public class ShopDataBase : MonoBehaviour
{
    [Header("作ったアイテムを格納するリスト")]public List<ItemObj> _itemObjs = new List<ItemObj>();
}

