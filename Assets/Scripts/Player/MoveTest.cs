using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _rotationSpeed = 600f;
    [Tooltip("xz���ʂ̍ő呬�x")]
    [SerializeField] private float _maxSurfaceSpeed = 0f;
    [Tooltip("y�����̍ő呬�x")]
    [SerializeField] private float _maxDimensionalSpeed = 0f;

    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    [Tooltip("�����l")]
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
        // ���������̐���
        // �ڒn���ĂȂ���Η�������
        if (!CheckGrounded())
        {
            _currentVer -= _gravity * Time.deltaTime;
            if (_currentVer < -_maxDimensionalSpeed)
            {
                _currentVer = -_maxDimensionalSpeed;
            }
        }
        // �ڒn���Ă��� ���� �W�����v���͂�����΃W�����v����B
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentVer = _jumpPower;
        }
        // �ڒn���Ă���Α��x�͐������x��0�B
        else
        {
            _currentVer = 0f;
        }

        // ���������̐���
        if (moveInput.sqrMagnitude > 0.3f)
        {
            // ���͂���������������
            _currentHol += _moveSpeed * Time.deltaTime;

            if (_currentHol > _maxSurfaceSpeed)
            {
                _currentHol = _maxSurfaceSpeed;
            }

            // ���͕�����ۑ�����
            _cachedDir = new Vector3(moveInput.x, 0f, moveInput.y);

            // ��]�̐���
            // ���C���J��������ɕ������w�肷��B
            _cachedDir = Camera.main.transform.TransformDirection(_cachedDir);
            _targetRotation = Quaternion.LookRotation(_cachedDir, Vector3.up);
            _targetRotation.x = 0f;
            _targetRotation.z = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        }
        // ���͂��Ȃ���Ό�������
        else
        {
            _currentHol -=
                _decreaseSpeed * Time.deltaTime;

            if (_currentHol < 0f)
            {
                _currentHol = 0f;
            }
        }
        // ���ʂ̊��蓖��
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

        //TODO�F���肪�ɂ����߁A����C��
        return Physics.Raycast(transform.position, Vector3.down, 1f);
    }
}
