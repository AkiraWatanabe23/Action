using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _timer = 100f;
    public float Timer { get => _timer; set => _timer = value; }

    private static GameManager _instance = default;

    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            //GameOver
        }
    }

    public void SetGameStatus()
    {
        //ゲームの初期設定(Timer等)
    }
}
