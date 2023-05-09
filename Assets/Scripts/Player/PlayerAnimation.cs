using UnityEngine;

[System.Serializable]
public class PlayerAnimation
{
    [Header("各Animationのパラメータ")]
    [SerializeField] private float _move = 1f;

    //各Animationを関数にまとめる
    private Animator _anim = default;

    public void Init(Animator anim)
    {
        _anim = anim;
    }

    public void AnimIdle(bool play)
    {
        _anim.SetBool("IsIdle", play);
    }

    public void AnimMove(bool move)
    {
        _anim.SetBool("IsMove", move);
        _anim.SetFloat("Move", _move);
    }

    public void AnimAttack(bool attack)
    {
        _anim.SetBool("IsAttack", attack);
    }

    public void AnimDamaged(bool damage)
    {
        _anim.SetBool("IsDamage", damage);
    }

    public void AnimDead()
    {

    }
}
