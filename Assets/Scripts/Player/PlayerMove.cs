using UnityEngine;
using UsefulPhysics;

[System.Serializable]
public class PlayerMove
{
    [Header("移動系パラメータ")]
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    [SerializeField] private float _rotateSpeed = 600f;

    [Header("調整値")]
    [Tooltip("重力")]
    [SerializeField] private float _gravity = 9.8f;
    [Tooltip("xz平面の最大速度")]
    [SerializeField] private float _maxSurfaceSpeed = 0f;
    [Tooltip("y方向の最大速度")]
    [SerializeField] private float _maxDimensionalSpeed = 0f;
    [Tooltip("減速値")]
    [SerializeField] private float _decreaseSpeed = 1f;
    [SerializeField] private Overlaps _overlap = default;
    [Tooltip("OverlapSphereのoffset(Playerの中心からどれくらいずらすか)")]
    [SerializeField] private Vector3 _overlapOffset = Vector3.zero;

    private CharacterController _controller = default;
    private Transform _transform = default;
    private PlayerAnimation _animation = default;

    private float _currentHolSpeed = 0f;
    private float _currentVerSpeed = 0f;

    private Vector3 _moveDir = Vector3.zero;
    private Quaternion _targetRotation = default;

    public void Init(CharacterController con, Transform transform, PlayerAnimation animation)
    {
        _controller = con;
        _transform = transform;
        _animation = animation;

        _targetRotation = _transform.rotation;
    }

    public void Update()
    {
        CharaMove(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void CharaMove(Vector2 input)
    {
        // 垂直方向の制御
        // 接地してなければ落下する
        if (!_overlap.OverlapSphere(_transform.position + _overlapOffset))
        {
            _currentVerSpeed -= _gravity * Time.deltaTime;
            if (_currentVerSpeed < -_maxDimensionalSpeed)
            {
                _currentVerSpeed = -_maxDimensionalSpeed;
            }
        }
        // 接地している かつ ジャンプ入力があればジャンプする。
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentVerSpeed = _jumpPower;
        }
        // 接地していれば速度は垂直速度は0。
        else
        {
            _currentVerSpeed = 0f;
        }

        // 水平方向の制御
        if (input.sqrMagnitude > 0.3f)
        {
            // 入力がある限り加速する
            _currentHolSpeed += _moveSpeed * Time.deltaTime;

            if (_currentHolSpeed > _maxSurfaceSpeed)
            {
                _currentHolSpeed = _maxSurfaceSpeed;
            }

            // 入力方向を保存する
            _moveDir = new Vector3(input.x, 0f, input.y);

            // 回転の制御
            // メインカメラを基準に方向を指定する。
            _moveDir = Camera.main.transform.TransformDirection(_moveDir);
            _targetRotation = Quaternion.LookRotation(_moveDir, Vector3.up);
            _targetRotation.x = 0f;
            _targetRotation.z = 0f;
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _targetRotation, _rotateSpeed * Time.deltaTime);
        }
        // 入力がなければ減速する
        else
        {
            _currentHolSpeed -=
                _decreaseSpeed * Time.deltaTime;

            if (_currentHolSpeed < 0f)
            {
                _currentHolSpeed = 0f;
            }
        }
        // 結果の割り当て
        Vector3 moveSpeed = _moveDir.normalized * _currentHolSpeed * Time.deltaTime;
        moveSpeed.y = _currentVerSpeed * Time.deltaTime;

        _controller.Move(moveSpeed);
    }
}
