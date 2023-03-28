using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;

    private CharacterController _controller = default;
    private Transform _trans = default;

    private Vector3 _moveDir = Vector3.zero;
    private float _hol = 0f;
    private float _ver = 0f;

    public void Init(CharacterController con, Transform trans)
    {
        _controller = con;
        _trans = trans;
    }

    public void Update()
    {
        _hol = Input.GetAxisRaw("Horizontal");
        _ver = Input.GetAxisRaw("Vertical");

        //接地判定
        if (_controller.isGrounded)
        {
            _moveDir.z = _ver * _moveSpeed;

            _trans.Rotate(0f, _hol * _moveSpeed, 0f);

            if (Input.GetButtonDown("Jump"))
            {
                _moveDir.y = _jumpPower;
            }
        }
        _moveDir.y -= 20f * Time.deltaTime;

        Vector3 globaldir = _trans.TransformDirection(_moveDir);
        _controller.Move(globaldir * Time.deltaTime);

        if (_controller.isGrounded)
        {
            _moveDir.y = 0;
        }
    }
}
