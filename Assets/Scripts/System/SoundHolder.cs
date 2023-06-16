using UnityEngine;

[System.Serializable]
public class SoundHolder
{
    [SerializeField] private AudioClip[] _bgm = default;
    [SerializeField] private AudioClip[] _se = default;

    private AudioSource _sourceBGM = default;

    public void Init(AudioSource source)
    {
        _sourceBGM = source;
        _sourceBGM.playOnAwake = true;
        _sourceBGM.loop = true;
    }

    public void PlayBGM(AudioClip clip)
    {
        _sourceBGM.clip = clip;
        _sourceBGM.Play();
    }

    public void PlaySE(AudioSource source, AudioClip clip)
    {
        source.loop = false;

        source.clip = clip;
        source.Play();
    }
}
