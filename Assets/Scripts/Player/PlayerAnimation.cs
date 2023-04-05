using UnityEngine;

[System.Serializable]
public class PlayerAnimation
{
    [Header("Animationの各パラメータ")]
    [SerializeField] private float _move = 1f;

    //各Animationを関数にまとめる
    private Animator _anim = default;

    public void Init(Animator anim)
    {
        _anim = anim;
    }

    public void AnimIdle(bool play)
    {
        _anim.SetBool("Idle", play);
    }

    public void AnimMove()
    {
        _anim.SetFloat("Move", _move);
    }

    public void AnimAttack()
    {

    }

    public void AnimDamaged()
    {

    }

    public void AnimDead()
    {

    }
}
