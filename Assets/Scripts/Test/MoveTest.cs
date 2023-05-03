using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveTest : MonoBehaviour
{
    private CharacterController characterController;  // CharacterController型の変数
    [SerializeField] public float moveSpeed;  //移動速度

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //float inputVertical = Input.GetAxisRaw("Vertical");

        //// プレイヤーの向きに応じた移動方向の計算
        //Vector3 moveDirection = Vector3.zero;
        //if (inputVertical < 0)
        //{ // sキーが押された場合
        //    float angle = transform.eulerAngles.y; // プレイヤーの向きを取得
        //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up); // プレイヤーの向きに応じた回転を計算
        //    moveDirection = rotation * Vector3.forward * moveSpeed * -1; // プレイヤーの向きに応じた移動方向を計算
        //}
        //characterController.Move(moveDirection * Time.deltaTime);

        // 入力の取得
        //float inputVertical = Input.GetAxisRaw("Vertical");

        //// プレイヤーの向きに応じた移動方向の計算
        //Vector3 moveDirection = Vector3.zero;
        //if (inputVertical < 0)
        //{ // sキーが押された場合
        //    float angle = transform.eulerAngles.y + 180f; // プレイヤーの向きを取得して、180度回転させる
        //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up); // プレイヤーの向きに応じた回転を計算
        //    moveDirection = rotation * Vector3.forward * moveSpeed; // プレイヤーの向きに応じた移動方向を計算
        //}
        //characterController.Move(moveDirection * Time.deltaTime);

        // 入力の取得
        float inputVertical = Input.GetAxisRaw("Vertical");

        // プレイヤーの向きに応じた移動方向の計算
        Vector3 moveDirection = Vector3.zero;
        if (inputVertical < 0)
        { // sキーが押された場合
            float targetAngle = transform.eulerAngles.y + 180f; // プレイヤーの向きを取得して、180度回転させる
            float currentAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // 現在の角度から目標の角度まで、スムーズに回転する処理を追加
            transform.eulerAngles = Vector3.up * currentAngle; // 回転を反映した角度に設定
        }
        moveDirection = transform.forward * moveSpeed; // 回転を反映した向きに移動するように修正
        characterController.Move(moveDirection * Time.deltaTime);
    }

    float turnSmoothTime = 0.1f; // 回転のスムーズ処理にかかる時間
    float turnSmoothVelocity; // 回転のスムーズ処理に必要な変数
}
