using Constants;
using System;
using UnityEngine;

[Serializable]
public class PlayerAnimation
{
    [SerializeField] private AnimationClip[] _clips = default;

    private string _animName = "";
    //各Animationを関数にまとめる
    private Animator _anim = default;

    private PlayerMove _move = default;

    private float _currentSurfaceSpeed = 0f;
    private float _maxSurfaceSpeed = 0f;

    public void Init(Animator anim, PlayerMove move)
    {
        _anim = anim;
        _move = move;

        _maxSurfaceSpeed = move.MaxSurfaceSpeed;

        //Animationの各ステート名を取得
        _clips = _anim.runtimeAnimatorController.animationClips;
        //Array.ForEach(_clips, clip => Debug.Log(clip.name));

        Setup();
    }

    private void Setup()
    {
        Array.ForEach(_clips, clip => _anim.SetBool(clip.name, false));

        _animName = Consts.ANIM_IDLE;
    }

    public void ChangeAnimToIdle()
    {
        if (_animName == Consts.ANIM_MOVE)
        {
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {

            }

            _anim.SetFloat("MoveValue", _currentSurfaceSpeed / _maxSurfaceSpeed);
            if (_currentSurfaceSpeed / _maxSurfaceSpeed >= 0.3f)
            {
                return;
            }
        }
        else
        {
            _anim.SetBool(_animName, false);
        }
        _animName = Consts.ANIM_IDLE;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimToMove()
    {
        _currentSurfaceSpeed = _move.CurrentSurfaceSpeed;

        //_animName = Consts.ANIM_MOVE;
        _anim.SetFloat("MoveValue", _currentSurfaceSpeed / _maxSurfaceSpeed);
    }

    public void ChangeAnimToJump()
    {
        _anim.SetBool(_animName, false);

        _animName = Consts.ANIM_JUMP;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimToAttack()
    {
        _anim.SetBool(_animName, false);

        _animName = Consts.ANIM_ATTACK;
        _anim.SetBool(_animName, true);
    }
}
