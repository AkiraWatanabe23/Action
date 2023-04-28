using UnityEngine;

public class WanderingRange : MonoBehaviour
{
    [SerializeField] GameObject _pos = default;
    [Tooltip("半径")]
    [Range(10f, 40f)]
    [SerializeField] private float _radius = 30f;
    [Tooltip("いくつのposを作るか")]
    [SerializeField] private int _posCount = 10;
    [Tooltip("徘徊する箇所のプレハブ")]
    [SerializeField] private GameObject _wanderPrefab = default;

    [Header("Debug")]
    [Tooltip("true...円内、false...球内")]
    [SerializeField] private bool _isCircle = false;
    [Tooltip("移動するか")]
    [SerializeField] private bool _isMove = false;

    private SphereCollider _collider = default;
    private Transform[] _wanderingPos = default;

    public bool IsMove => _isMove;
    public Transform[] WanderingPos => _wanderingPos;

    private void Awake()
    {
        _collider = _pos.GetComponent<SphereCollider>();
        _collider.radius = _radius;
        _collider.isTrigger = true;

        _wanderingPos = new Transform[_posCount];

        if (_isCircle)
        {
            //指定した半径の円内のランダムな位置にオブジェクトを生成する(xz平面)
            for (int i = 0; i < _posCount; i++)
            {
                var circlePos = _radius * Random.insideUnitCircle;
                var spawnPos = new Vector3(circlePos.x, 0, circlePos.y) + transform.position;

                var pos = Instantiate(_wanderPrefab, spawnPos, Quaternion.identity);
                _wanderingPos[i] = pos.transform;
                pos.transform.SetParent(_pos.transform);
            }
        }
        else
        {
            //3D空間(球内)に生成
            for (int i = 0; i < _posCount; i++)
            {
                var spawnPos = _radius * Random.insideUnitSphere + transform.position;

                var pos = Instantiate(_wanderPrefab, spawnPos, Quaternion.identity);
                _wanderingPos[i] = pos.transform;
                pos.transform.SetParent(_pos.transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            //Playerが自分の徘徊範囲内に入ってきたら動く
            _isMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            //出たらやめる
            _isMove = false;
        }
    }
}
