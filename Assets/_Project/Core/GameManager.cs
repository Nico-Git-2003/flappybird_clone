using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    
    public enum GameState { Playing, Paused, GameOver }
    public GameState CurrentState { get; private set; }

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
}