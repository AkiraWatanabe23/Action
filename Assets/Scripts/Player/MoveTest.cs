using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _rotationSpeed = 600f;
    [Tooltip("xz平面の最大速度")]
    [SerializeField] private float _maxSurfaceSpeed = 0f;
    [Tooltip("y方向の最大速度")]
    [SerializeField] private float _maxDimensionalSpeed = 0f;

    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    [Tooltip("減速値")]
    [SerializeField] private float _decreaseSpeed = 1f;

    private CharacterController _controller = default;

    private float _currentHol = 0f;
    private float _currentVer = 0f;

    private Vector3 _cachedDir = default;
    private Quaternion _targetRotation = default;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void Move(Vector2 moveInput)
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
        if (moveInput.sqrMagnitude > 0.3f)
        {
            // 入力がある限り加速する
            _currentHol += _moveSpeed * Time.deltaTime;

            if (_currentHol > _maxSurfaceSpeed)
            {
                _currentHol = _maxSurfaceSpeed;
            }

            // 入力方向を保存する
            _cachedDir = new Vector3(moveInput.x, 0f, moveInput.y);

            // 回転の制御
            // メインカメラを基準に方向を指定する。
            _cachedDir = Camera.main.transform.TransformDirection(_cachedDir);
            _targetRotation = Quaternion.LookRotation(_cachedDir, Vector3.up);
            _targetRotation.x = 0f;
            _targetRotation.z = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
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
        Vector3 moveSpeed = _cachedDir.normalized * _currentHol * Time.deltaTime;
        moveSpeed.y = _currentVer * Time.deltaTime;

        _controller.Move(moveSpeed);
    }

    private bool CheckGrounded()
    {
        if (_controller.isGrounded)
        {
            return true;
        }

        //TODO：判定が緩いため、今後修正
        return Physics.Raycast(transform.position, Vector3.down, 1f);
    }
}
