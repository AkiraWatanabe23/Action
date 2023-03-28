using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerHealth : IDamage
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
            //‚â‚ç‚ê‚½
        }
    }
}
