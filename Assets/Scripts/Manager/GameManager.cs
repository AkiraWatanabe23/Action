﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool _isGameStart = false;

    private float _timer = 300f;
    private int _enemyKillCount = 0;

    private int _maxKillCount = 50;

    private UIManager _uiManager = default;
    private static GameManager _instance = default;

    public bool IsGameStart => _isGameStart;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            _uiManager.TimerText.text = _timer.ToString("F0");
        }
    }
    public int KillCount
    {
        get => _enemyKillCount;
        set
        {
            _enemyKillCount = value;
            _uiManager.CountText.text = $"{ value }  /  { _maxKillCount }";

            if (value >= _maxKillCount) GameFinish();
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
            Timer -= Time.deltaTime;
            if (_timer < 0)
            {
                GameFinish();
            }
        }
    }

    /// <summary> ゲーム開始時に呼び出す関数 </summary>
    public void SetGameStatus(UIManager manager, EnemyManager enemyManager)
    {
        _uiManager = manager;
        _maxKillCount = (int)(enemyManager.gameObject.transform.childCount * 0.8f);
        KillCount = 0;
    }

    /// <summary> 指示が出た場合に呼び出し、ゲームを開始する </summary>
    public void GameStart()
    {
        _isGameStart = true;
    }

    private void GameFinish()
    {
        _uiManager.ResultPrefab.SetActive(true);
        _uiManager.ResultText.text = _uiManager.CountText.text = $"{ _enemyKillCount }  /  { _maxKillCount }";
    }
}
