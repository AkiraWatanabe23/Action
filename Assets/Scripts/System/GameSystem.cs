using Constants;
using System;
using System.Linq;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private bool[] _missions = new bool[4];

    private void Start()
    {
        Array.ForEach(_missions, m => m = false);
    }

    private void Update()
    {
        
    }

    private void MissionClear(int index)
    {
        _missions[index] = true;

        if (_missions.All(m => m == true))
        {
            //GameClear
        }
    }

    /// <summary> 敵を一定数倒す </summary>
    private bool MissionOne()
    {
        if (Consts.CLEAR_KILL_COUNT <= GameManager.Instance.KillCount)
        {
            return true;
        }

        return false;
    }
}
