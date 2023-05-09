using Constants;
using UnityEngine;

[System.Serializable]
public class PlayerAnimation
{
    [SerializeField] private AnimationClip[] _clips = default;
    [Header("各Animationのパラメータ")]
    [SerializeField] private float _move = 1f;

    private string _animName = "";
    //各Animationを関数にまとめる
    private Animator _anim = default;

    public void Init(Animator anim)
    {
        _anim = anim;

        //Animationの各ステート名を取得
        _clips = _anim.runtimeAnimatorController.animationClips;
        for (int i = 0; i < _clips.Length; i++)
        {
            Debug.Log(_clips[i].name);
        }

        Setup();
    }

    private void Setup()
    {
        _animName = _clips[0].name;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimation(string newAnimationName)
    {
        if (_animName == Consts.ANIM_MOVE)
        {
            _anim.SetFloat("MoveValue", 0);
        }
        _animName = newAnimationName;

        if (newAnimationName == Consts.ANIM_MOVE)
        {
            _anim.SetFloat("MoveValue", _move);
        }
        _anim.SetBool(_animName, true);
    }
}
