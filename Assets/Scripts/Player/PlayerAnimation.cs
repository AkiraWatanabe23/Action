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
        Array.ForEach(_clips, clip => Debug.Log(clip.name));

        Setup();
    }

    private void Setup()
    {
        Array.ForEach(_clips, clip => _anim.SetBool(clip.name, false));

        _animName = Consts.ANIM_IDLE;
    }

    public void ChangeAnimation(string newAnimationName)
    {
        if (newAnimationName == Consts.ANIM_MOVE)
        {
            _anim.SetFloat("MoveValue", _currentSurfaceSpeed / _maxSurfaceSpeed);
        }

        _anim.SetBool(_animName, false);
        _animName = newAnimationName;

        _anim.SetBool(_animName, true);
    }

    /// <summary> MoveAnimation用 </summary>
    public void ChangeAnimation(string newAnimationName, bool isDecreace)
    {
        _currentSurfaceSpeed = _move.CurrentSuefaceSpeed;
        if (!isDecreace)
        {
            ChangeAnimation(newAnimationName);
        }
        else
        {
            _anim.SetFloat("MoveValue", _currentSurfaceSpeed / _maxSurfaceSpeed);

            if (_currentSurfaceSpeed / _maxSurfaceSpeed < 0.1f)
            {
                ChangeAnimation(Consts.ANIM_IDLE);
            }
        }
    }
}
