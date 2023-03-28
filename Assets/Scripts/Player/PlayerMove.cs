using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;

    private CharacterController _controller = default;
    private Transform _trans = default;
    private Vector3 _moveDir = Vector3.zero;
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
            _moveDir = new Vector3(hol, 0f, ver) * _moveSpeed;
            _trans.Rotate(0f, hol, 0f);

            //ローカル座標をワールド座標に変換する
            _moveDir = _trans.TransformDirection(_moveDir);

            if (Input.GetButtonDown("Jump"))
            {
                _moveDir.y = _jumpPower;
            }
        }
        //CharacterController.Move()には重力がないため動的にかける
        _moveDir.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDir * Time.deltaTime);
    }
}
