using UnityEngine;

public class WanderingRange : MonoBehaviour
{
    [Tooltip("半径")]
    [Range(10f, 30f)]
    [SerializeField] private float _radius = 1f;
    [Tooltip("いくつのposを作るか")]
    [SerializeField] private int _posCount = 1;
    [SerializeField] private GameObject _prefab = default;

    [Header("Debug")]
    [Tooltip("true...円内、false...球内")]
    [SerializeField] private bool _isCircle = false;

    private Vector3 _pos = default;

    private void Start()
    {
        _pos = transform.position;

        if (_isCircle)
        {
            //指定した半径の円内のランダムな位置にオブジェクトを生成する(xz平面)
            for (int i = 0; i < _posCount; i++)
            {
                var circlePos = _radius * Random.insideUnitCircle;
                var spawnPos = new Vector3(circlePos.x, 0, circlePos.y) + _pos;

                Instantiate(_prefab, spawnPos, Quaternion.identity);
            }
        }
        else
        {
            //3D空間(球内)に生成
            for (int i = 0; i < _posCount; i++)
            {
                var spawnPos = _radius * Random.insideUnitSphere + _pos;

                Instantiate(_prefab, spawnPos, Quaternion.identity);
            }
        }
    }

    private void OnGUI()
    {
        
    }
}
