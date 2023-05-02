using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;

    private CharacterController _controller = default;
    private Transform _trans = default;
    private Vector3 _moveDir = Vector3.zero;
    private Vector3 _beforeDir = Vector3.zero;
    private readonly float _gravity = 20f;

    public void Init(CharacterController con, Transform trans)
    {
        _controller = con;
        _trans = trans;
    }

    public void Update()
    {
        float hol = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        //接地中なら
        if (_controller.isGrounded)
        {
            //移動の入力
            _moveDir.x = hol;
            _moveDir.z = ver * _moveSpeed;
            _trans.Rotate(0f, hol, 0f);

            if (ver < 0f)
            {
                //後ろ方向の入力があった場合
                //_trans.rotation = Quaternion.Euler(0f, 180f, 0f);
                float angle = Vector3.SignedAngle(_trans.forward, _moveDir.normalized, _trans.up);
                _trans.Rotate(0f, angle, 0f);
            }

            _moveDir = Vector3.Lerp(_beforeDir, _moveDir, _moveSpeed * Time.deltaTime);
            _beforeDir = _moveDir;

            if (Input.GetButtonDown("Jump"))
            {
                _moveDir.y = _jumpPower;
            }
        }
        //CharacterController.Move()には重力がないため動的にかける
        _moveDir.y -= _gravity * Time.deltaTime;

        //ローカル座標をワールド座標に変換する
        Vector3 dir = _trans.TransformDirection(_moveDir);
        _controller.Move(dir * Time.deltaTime);
    }
}
