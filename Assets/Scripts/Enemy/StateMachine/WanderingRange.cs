using System;
using UnityEngine;

/// <summary> 指定した半径の円内のランダムな位置にオブジェクトを生成する </summary>
public class WanderingRange : MonoBehaviour
{
    [Tooltip("生成円の半径")]
    [Range(10f, 40f)]
    [SerializeField] private float _radius = 30f;
    [Tooltip("いくつのposを作るか")]
    [SerializeField] private int _posCount = 10;
    [Tooltip("徘徊する地点のプレハブ")]
    [SerializeField] private GameObject _wanderPrefab = default;

    [Header("Debug")]
    [Tooltip("true...円内、false...球内")]
    [SerializeField] private bool _isCircle = false;
    [Tooltip("Enemyが徘徊を行うか")]
    [SerializeField] private bool _isMove = false;

    private Transform[] _wanderingPos = default;

    public event Action<bool> SetCanvas = default;

    public bool IsMove => _isMove;
    public Transform[] WanderingPos => _wanderingPos;

    private void Awake()
    {
        var posCollider = GetComponent<SphereCollider>();

        posCollider.radius = _radius * 2;
        posCollider.isTrigger = true;

        _wanderingPos = new Transform[_posCount];

        if (_isCircle)
        {
            //xz平面(円内)
            for (int i = 0; i < _posCount; i++)
            {
                var circlePos = _radius * UnityEngine.Random.insideUnitCircle;
                var spawnPos = new Vector3(circlePos.x, 0, circlePos.y) + transform.position;

                var pos = Instantiate(_wanderPrefab, spawnPos, Quaternion.identity);
                _wanderingPos[i] = pos.transform;
                pos.transform.SetParent(posCollider.transform);
            }
        }
        else
        {
            //3D空間(球内)
            for (int i = 0; i < _posCount; i++)
            {
                var spawnPos = _radius * UnityEngine.Random.insideUnitSphere + transform.position;

                var pos = Instantiate(_wanderPrefab, spawnPos, Quaternion.identity);
                _wanderingPos[i] = pos.transform;
                pos.transform.SetParent(posCollider.transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            //Playerが自分の徘徊範囲内に入ってきたら動く
            _isMove = true;
            SetCanvas?.Invoke(_isMove);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            //出たらやめる
            _isMove = false;
            SetCanvas?.Invoke(_isMove);
        }
    }
}
