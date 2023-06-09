using UnityEngine;
[CreateAssetMenu(fileName = "New PowerUp Object", menuName = "Inventory System/Items/PowerUp")]
public class PowerUpObject : ItemObj
{
    [SerializeField] int _powerUpOffencivePower;
    [SerializeField] int _powerUppowerUpDiffensivePower;
    public void Awake()
    {
        _type = ItemType.PowerUP;
    }
    public override void UseItem()
    {
        var player = FindObjectOfType<PlayerController>();
        player.Attack.AttackValue += _powerUpOffencivePower;
        //player._diffensivePower += _powerUppowerUpDiffensivePower;
    }

}
