using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool _isGameStart = false;

    private float _timer = 100f;

    private static GameManager _instance = default;

    public float Timer { get => _timer; set => _timer = value; }

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
                //GameOver
            }
        }
    }

    public void SetGameStatus()
    {
        //ゲームの初期設定(Timer等)
    }

    /// <summary> 指示が出た場合に呼び出し、ゲームを開始する </summary>
    public void GameStart()
    {
        _isGameStart = true;
    }

    public void EnemySpawn(int count, GameObject enemy, GameObject positions)
    {
        for (int i = 0; i < count; i++)
        {
            var e =
                Instantiate(enemy, positions.transform.GetChild(i).transform.position, Quaternion.identity);

            if (e.TryGetComponent(out EnemyController controller))
            {
                controller.Wandering = positions.transform.GetChild(i).GetComponent<WanderingRange>();
            }
        }
    }
}
