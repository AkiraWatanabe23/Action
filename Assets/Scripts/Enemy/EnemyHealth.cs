using UnityEngine;

[System.Serializable]
public class EnemyHealth : IDamage
{
    [SerializeField] private int _hp = 100;

    public void Init()
    {

    }

    public void ReceiveDamege(int value)
    {
        _hp -= value;

        if (_hp <= 0)
        {
            //やられた
        }
    }
}
