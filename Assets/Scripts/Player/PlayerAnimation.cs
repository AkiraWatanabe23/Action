﻿using Constants;
using System;
using UnityEngine;

[Serializable]
public class PlayerAnimation
{
    [SerializeField] private AnimationClip[] _clips = default;

    private string _animName = "";
    //各Animationを関数にまとめる
    private Animator _anim = default;

    public void Init(Animator anim)
    {
        _anim = anim;

        //Animationの各ステート名を取得
        _clips = _anim.runtimeAnimatorController.animationClips;
        Array.ForEach(_clips, clip => Debug.Log(clip.name));

        Setup();
    }

    private void Setup()
    {
        Array.ForEach(_clips, clip => _anim.SetBool(clip.name, false));

        _animName = Consts.ANIM_IDLE;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimation(string newAnimationName)
    {
        _anim.SetBool(_animName, false);
        _animName = newAnimationName;

        _anim.SetBool(_animName, true);
    }
}
