using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//�A�C�e���V���b�v�ɕ��ԃA�C�e���̔z��
public class ShopDataBase : MonoBehaviour
{
    [Header("������A�C�e�����i�[���郊�X�g")] public List<ItemObj> _itemObjs = new();

    [SerializeField] private Text _discription = default;
    [SerializeField] private Image _image = default;

    public Text Discription { get => _discription; set => _discription = value; }
    public Image Image { get => _image; set => _image = value; }
}

