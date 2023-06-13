using Constants;
using System;
using UnityEngine;

/// <summary> 各Animationを関数にまとめる </summary>
[Serializable]
public class PlayerAnimation
{
    private string _animName = "";
    private Animator _anim = default;

    private PlayerMove _move = default;

    private float _currentSurfaceSpeed = 0f;
    private float _maxSurfaceSpeed = 0f;

    private string _currentAnimation = "";

    public void Init(Animator anim, PlayerMove move)
    {
        _anim = anim;
        _move = move;

        _maxSurfaceSpeed = move.MaxSurfaceSpeed;

        _currentAnimation = Consts.ANIM_IDLE;
        _animName = Consts.ANIM_IDLE;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimToIdle()
    {
        if (_currentAnimation == Consts.ANIM_MOVE)
        {
            _currentSurfaceSpeed = _move.CurrentSurfaceSpeed;
            var speed = _currentSurfaceSpeed / _maxSurfaceSpeed;

            _anim.SetFloat("MoveValue", speed);
            if (speed >= 0.1f)
            {
                return;
            }
        }
        else
        {
            _anim.SetBool(_animName, false);
        }
        _currentAnimation = Consts.ANIM_IDLE;

        _animName = Consts.ANIM_IDLE;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimToMove()
    {
        _currentSurfaceSpeed = _move.CurrentSurfaceSpeed;
        _currentAnimation = Consts.ANIM_MOVE;

        _anim.SetBool(_animName, false);
        if (_animName == Consts.ANIM_ATTACK)
        {
            _animName = Consts.ANIM_IDLE;
            _anim.SetBool(_animName, true);
        }

        _anim.SetFloat("MoveValue", _currentSurfaceSpeed / _maxSurfaceSpeed);
    }

    public void ChangeAnimToJump()
    {
        _anim.SetBool(_animName, false);
        _currentAnimation = Consts.ANIM_JUMP;

        _animName = Consts.ANIM_JUMP;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimToAttack()
    {
        if (_currentAnimation == Consts.ANIM_MOVE)
        {
            _currentSurfaceSpeed = _move.CurrentSurfaceSpeed;
            var speed = _currentSurfaceSpeed / _maxSurfaceSpeed;

            _anim.SetFloat("MoveValue", speed);
        }
        else
        {
            _anim.SetBool(_animName, false);
        }
        _currentAnimation = Consts.ANIM_ATTACK;

        _animName = Consts.ANIM_ATTACK;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimToDamage()
    {
        if (_animName != Consts.ANIM_MOVE)
        {
            _anim.SetBool(_animName, false);
        }
        _currentAnimation = Consts.ANIM_DAMAGE;

        _animName = Consts.ANIM_DAMAGE;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimToDeath()
    {
        _currentAnimation = Consts.ANIM_DEATH;

        _animName = Consts.ANIM_DEATH;
        _anim.SetBool(_animName, true);
    }
}
