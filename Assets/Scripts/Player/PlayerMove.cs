using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [Tooltip("移動方式")]
    [SerializeField] private MoveType _moveType = MoveType.Chara;

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

    private CharacterController _controller = default;
    private Transform _trans = default;
    private Rigidbody _rb = default;

    private float _currentHol = 0f;
    private float _currentVer = 0f;

    private Vector3 _moveDir = Vector3.zero;
    private Quaternion _targetRotation = default;

    public MoveType MoveType => _moveType;

    public void Init(CharacterController con, Transform trans)
    {
        _controller = con;
        _trans = trans;

        _targetRotation = _trans.rotation;
    }

    public void Init(Transform trans, Rigidbody rigidbody)
    {
        _trans = trans;
        _rb = rigidbody;

        _targetRotation = _trans.rotation;
    }

    public void Update()
    {
        CharaMove(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    public void FixedUpdate()
    {
        RigidMove();
    }

    private void CharaMove(Vector2 input)
    {
        // 垂直方向の制御
        // 接地してなければ落下する
        if (!CheckGrounded())
        {
            _currentVer -= _gravity * Time.deltaTime;
            if (_currentVer < -_maxDimensionalSpeed)
            {
                _currentVer = -_maxDimensionalSpeed;
            }
        }
        // 接地している かつ ジャンプ入力があればジャンプする。
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentVer = _jumpPower;
        }
        // 接地していれば速度は垂直速度は0。
        else
        {
            _currentVer = 0f;
        }

        // 水平方向の制御
        if (input.sqrMagnitude > 0.3f)
        {
            // 入力がある限り加速する
            _currentHol += _moveSpeed * Time.deltaTime;

            if (_currentHol > _maxSurfaceSpeed)
            {
                _currentHol = _maxSurfaceSpeed;
            }

            // 入力方向を保存する
            _moveDir = new Vector3(input.x, 0f, input.y);

            // 回転の制御
            // メインカメラを基準に方向を指定する。
            _moveDir = Camera.main.transform.TransformDirection(_moveDir);
            _targetRotation = Quaternion.LookRotation(_moveDir, Vector3.up);
            _targetRotation.x = 0f;
            _targetRotation.z = 0f;
            _trans.rotation = Quaternion.RotateTowards(_trans.rotation, _targetRotation, _rotateSpeed * Time.deltaTime);
        }
        // 入力がなければ減速する
        else
        {
            _currentHol -=
                _decreaseSpeed * Time.deltaTime;

            if (_currentHol < 0f)
            {
                _currentHol = 0f;
            }
        }
        // 結果の割り当て
        Vector3 moveSpeed = _moveDir.normalized * _currentHol * Time.deltaTime;
        moveSpeed.y = _currentVer * Time.deltaTime;

        _controller.Move(moveSpeed);
    }

    private void RigidMove()
    {
        float hol = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (!_rb.isKinematic)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }

            _moveDir = new Vector3(hol, _rb.velocity.y, ver);

            if (_moveDir.magnitude > 0.1f)
            {
                _targetRotation = Quaternion.LookRotation(_moveDir);
                _rb.MovePosition(_rb.position + _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime);
            }

            _trans.rotation = Quaternion.Slerp(_trans.rotation, _targetRotation, _rotateSpeed * Time.fixedDeltaTime);
        }
    }

    private bool CheckGrounded()
    {
        if (_controller.isGrounded)
        {
            return true;
        }

        //TODO：判定が緩いため、今後修正
        return Physics.Raycast(_trans.position, Vector3.down, 1f);
    }
}

public enum MoveType
{
    Chara,
    Rigid,
}
