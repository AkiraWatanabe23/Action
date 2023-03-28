using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [SerializeField] private AttackType _type = AttackType.Sword;

    public void Init()
    {

    }

    public void Attack()
    {
        //持っている武器によって分けたい
        switch (_type)
        {
            case AttackType.Sword:
                break;
            case AttackType.Gun:
                break;
            case AttackType.Hammer:
                break;
        }
    }
}

public enum AttackType
{
    Sword,
    Gun,
    Hammer
}
