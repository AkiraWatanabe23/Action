using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Object", menuName = "Inventory System/Items/Heal")]
public class HealObject : ItemObj
{
    [SerializeField] int _healValue;
    public override void UseItem()
    {
        var player = FindObjectOfType<PlayerController>();
        if (player.Health.HP < player.Health.MaxHp)
        {
            player.Health.HP = Mathf.Min(player.Health.HP + _healValue, player.Health.MaxHp);
        }
    }
    private void Awake()
    {
        //_type = ItemType.Consumable;
    }
}
