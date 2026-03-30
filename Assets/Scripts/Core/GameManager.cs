using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    
    public enum GameState { Playing, Paused, GameOver, Upgrade }
    public GameState CurrentState { get; set; }

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}