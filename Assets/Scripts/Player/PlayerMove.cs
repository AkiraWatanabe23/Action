using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private MoveType _moveType = MoveType.Chara;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;

    [SerializeField] private float _rotateSpeed = 1f;

    private CharacterController _controller = default;
    private Transform _trans = default;
    private Rigidbody _rb = default;
    private Vector3 _moveDir = Vector3.zero;

    private float _hol = 1f;
    private float _ver = 1f;
    private readonly float _gravity = 20f;

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
        CharaMove();
    }

    public void FixedUpdate()
    {
        RigidMove();
    }

    private void CharaMove()
    {
        _hol = Input.GetAxisRaw("Horizontal");
        _ver = Input.GetAxisRaw("Vertical");

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveDir.y = _jumpPower * Time.deltaTime;
            }
        }
        _moveDir.y -= _gravity * Time.deltaTime;

        _moveDir = new Vector3(_hol, 0f, _ver);
        _moveDir = _trans.TransformDirection(_moveDir);
        _moveDir *= _moveSpeed * Time.deltaTime;

        _controller.Move(_moveDir);

        if (_moveDir.magnitude > 0.1f)
        {
            _targetRotation = Quaternion.LookRotation(_moveDir);
            _trans.rotation = Quaternion.Slerp(_trans.rotation, _targetRotation, _rotateSpeed * Time.deltaTime);
        }
    }

    private void RigidMove()
    {
        _hol = Input.GetAxisRaw("Horizontal");
        _ver = Input.GetAxisRaw("Vertical");

        if (!_rb.isKinematic)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }

            _moveDir = new Vector3(_hol, _rb.velocity.y, _ver);

            if (_moveDir.magnitude > 0.1f)
            {
                _targetRotation = Quaternion.LookRotation(_moveDir);
                _rb.MovePosition(_rb.position + _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime);
            }

            _trans.rotation = Quaternion.Slerp(_trans.rotation, _targetRotation, _rotateSpeed * Time.fixedDeltaTime);
        }
    }
}

public enum MoveType
{
    Chara,
    Rigid,
}
