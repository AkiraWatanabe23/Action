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

    public void Damege(int value)
    {
        _hp -= value;
    }
}
