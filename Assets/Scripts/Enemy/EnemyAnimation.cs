using Constants;
using UnityEngine;

[System.Serializable]
public class EnemyAnimation
{
    private string _animName = "";
    private Animator _anim = default;

    public void Init(Animator anim)
    {
        _anim = anim;

        _animName = Consts.ANIM_IDLE;
        _anim.SetBool(_animName, true);
    }

    public void ChangeAnimation(string nextAnim)
    {
        _anim.SetBool(_animName, false);
        _anim.SetBool(nextAnim, true);

        _animName = nextAnim;
    }
}
