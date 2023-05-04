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
    private float _targetRot = 1f;

    public MoveType MoveType => _moveType;

    public void Init(CharacterController con, Transform trans)
    {
        _controller = con;
        _trans = trans;

        _targetRot = _trans.eulerAngles.y;
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

        //移動の入力
        _moveDir = new Vector3(_hol, _moveDir.y, _ver);
        _moveDir = _trans.TransformDirection(_moveDir);
        _moveDir *= _moveSpeed;

        _controller.Move(_moveDir * Time.deltaTime);

        if (_hol != 0f)
        {
            float dir = Mathf.Sign(_hol);
            _targetRot += dir * 90.0f;
            //_trans.Rotate(Vector3.up, dir * _rotateSpeed * Time.deltaTime);

            _targetRot = Mathf.Repeat(_targetRot, 360.0f);
        }
        
        float currentRotation = _trans.eulerAngles.y;
        float rotation = Mathf.MoveTowardsAngle(currentRotation, _targetRot, _rotateSpeed * Time.deltaTime);
        _trans.eulerAngles = new Vector3(0, rotation, 0);

        //接地中なら
        //if (_controller.isGrounded)
        //{

        //    _moveDir.x = _hol;
        //    _moveDir.z = _ver * _moveSpeed;
        //    _trans.Rotate(0f, _hol, 0f);

        //    if (_ver < 0f)
        //    {
        //        //後ろ方向の入力があった場合
        //        //_trans.rotation = Quaternion.Euler(0f, 180f, 0f);

        //        var angle = _trans.eulerAngles.y;
        //        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);

        //        _moveDir = rot * Vector3.forward * _moveSpeed * -1;
        //    }

        //    //_moveDir = Vector3.Lerp(_beforeDir, _moveDir, _moveSpeed * Time.deltaTime);
        //    //_beforeDir = _moveDir;

        //    if (Input.GetButtonDown("Jump"))
        //    {
        //        _moveDir.y = _jumpPower;
        //    }
        //}
        ////CharacterController.Move()には重力がないため動的にかける
        //_moveDir.y -= _gravity * Time.deltaTime;

        ////ローカル座標をワールド座標に変換する
        //Vector3 dir = _trans.TransformDirection(_moveDir);
        //_controller.Move(dir * Time.deltaTime);
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
