using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private MissionState[] _missions = default;
    [SerializeField] private int _missionCount = 0;

    private void Start()
    {
        _missions = new MissionState[_missionCount];
    }

    private void Update()
    {

    }
}

public enum MissionState
{
    UnChallenged,
    Challenging,
    Cleared,
}
