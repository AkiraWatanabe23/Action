using UnityEngine;

[System.Serializable]
public class EnemyMove
{
    [SerializeField] private MoveType _type = MoveType.Normal;

    public void Init()
    {

    }

    public void Update()
    {

    }
}

public enum MoveType
{
    Normal,
    Boss,
}
