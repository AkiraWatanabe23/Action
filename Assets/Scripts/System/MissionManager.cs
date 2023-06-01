using System.Linq;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private MissionState[] _missions = default;
    [SerializeField] private int _missionCount = 0;

    private void Start()
    {
        _missions = new MissionState[_missionCount];

        for (int i  = 0; i < _missionCount; i++)
        {
            _missions[i] = MissionState.UnChallenged;
        }
    }

    private void Update()
    {

    }

    private void MissionStart(int index)
    {
        Debug.Log($"Mission{index} を開始します。");
        _missions[index] = MissionState.Challenging;
    }

    private void MissionClear(int index)
    {
        Debug.Log($"Mission{index} をクリアしました。");
        _missions[index] = MissionState.Cleared;

        if (_missions.All(m => m == MissionState.Cleared))
        {
            //ミッション全部クリア
            Debug.Log("全てのミッションをクリアしました。");
        }
    }
}

public enum MissionState
{
    UnChallenged,
    Challenging,
    Cleared,
}
