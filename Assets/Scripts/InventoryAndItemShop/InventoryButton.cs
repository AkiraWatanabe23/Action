using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ShopDataBase _dataBase;
    public Inventory _inventory;
    ItemObj _item;
    public int _id = -1;
    [SerializeField] Text str;
    public void PickItem()
    {
        _item = _dataBase._itemObjs[_id];
        _item._itemcount--;
        _item.UseItem();
        if (_item._itemcount == 0)
        {
            _inventory._buttonDic.Remove(_id);
            Destroy(this.gameObject);
        }
        Text str = GetComponentInChildren<Text>();
        str.text = _item.ItemName + "Å~" + _item._itemcount;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _dataBase.Discription.text = _dataBase._itemObjs[_id]._description;
        _dataBase.Image.enabled = true;
        _dataBase.Image.sprite = _dataBase._itemObjs[_id]._prefab;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _dataBase.Discription.text = "";
        _dataBase.Image.enabled = false;
    }
}
