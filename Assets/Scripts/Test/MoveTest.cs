using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveTest : MonoBehaviour
{
    private CharacterController characterController;  // CharacterController�^�̕ϐ�
    [SerializeField] public float moveSpeed;  //�ړ����x

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //float inputVertical = Input.GetAxisRaw("Vertical");

        //// �v���C���[�̌����ɉ������ړ������̌v�Z
        //Vector3 moveDirection = Vector3.zero;
        //if (inputVertical < 0)
        //{ // s�L�[�������ꂽ�ꍇ
        //    float angle = transform.eulerAngles.y; // �v���C���[�̌������擾
        //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up); // �v���C���[�̌����ɉ�������]���v�Z
        //    moveDirection = rotation * Vector3.forward * moveSpeed * -1; // �v���C���[�̌����ɉ������ړ��������v�Z
        //}
        //characterController.Move(moveDirection * Time.deltaTime);

        // ���͂̎擾
        //float inputVertical = Input.GetAxisRaw("Vertical");

        //// �v���C���[�̌����ɉ������ړ������̌v�Z
        //Vector3 moveDirection = Vector3.zero;
        //if (inputVertical < 0)
        //{ // s�L�[�������ꂽ�ꍇ
        //    float angle = transform.eulerAngles.y + 180f; // �v���C���[�̌������擾���āA180�x��]������
        //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up); // �v���C���[�̌����ɉ�������]���v�Z
        //    moveDirection = rotation * Vector3.forward * moveSpeed; // �v���C���[�̌����ɉ������ړ��������v�Z
        //}
        //characterController.Move(moveDirection * Time.deltaTime);

        // ���͂̎擾
        float inputVertical = Input.GetAxisRaw("Vertical");

        // �v���C���[�̌����ɉ������ړ������̌v�Z
        Vector3 moveDirection = Vector3.zero;
        if (inputVertical < 0)
        { // s�L�[�������ꂽ�ꍇ
            float targetAngle = transform.eulerAngles.y + 180f; // �v���C���[�̌������擾���āA180�x��]������
            float currentAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // ���݂̊p�x����ڕW�̊p�x�܂ŁA�X���[�Y�ɉ�]���鏈����ǉ�
            transform.eulerAngles = Vector3.up * currentAngle; // ��]�𔽉f�����p�x�ɐݒ�
        }
        moveDirection = transform.forward * moveSpeed; // ��]�𔽉f���������Ɉړ�����悤�ɏC��
        characterController.Move(moveDirection * Time.deltaTime);
    }

    float turnSmoothTime = 0.1f; // ��]�̃X���[�Y�����ɂ����鎞��
    float turnSmoothVelocity; // ��]�̃X���[�Y�����ɕK�v�ȕϐ�
}
