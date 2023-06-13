using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool _isGameStart = false;

    private float _timer = 100f;
    private int _enemyKillCount = 0;

    private int _maxKillCount = 50;

    private static GameManager _instance = default;

    public bool IsGameStart => _isGameStart;
    public float Timer { get => _timer; set => _timer = value; }
    public int KillCount
    {
        get => _enemyKillCount;
        set
        {
            _enemyKillCount = value;
            if (value >= _maxKillCount) GameClear();
        }
    }
    public int MaxKillCount => _maxKillCount;

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
        if (_isGameStart)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                GameOver();
            }
        }
    }

    private void GameClear()
    {
        //Panelとか出して、また最初から
    }

    private void GameOver()
    {
        //やり直し（シーンのリロードとかがいいかな）
    }

    /// <summary> ゲーム開始時に呼び出す関数 </summary>
    public void SetGameStatus(EnemyManager enemyManager)
    {
        //ゲームの初期設定(Timer等)
        _maxKillCount = (int)(enemyManager.gameObject.transform.childCount * 0.8f);
        _enemyKillCount = 0;
    }

    /// <summary> 指示が出た場合に呼び出し、ゲームを開始する </summary>
    public void GameStart()
    {
        _isGameStart = true;
    }
}
