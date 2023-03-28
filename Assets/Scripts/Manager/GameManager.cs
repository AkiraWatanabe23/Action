using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = default;

    public static GameManager Instance { get => _instance; set => _instance = value; }

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
        
    }
}
