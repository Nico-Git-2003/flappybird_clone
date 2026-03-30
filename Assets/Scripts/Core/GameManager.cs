using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    //Game State
    public enum GameState { Playing, Paused, GameOver, Upgrade }
    public GameState CurrentState { get; set; }
    
    //Game Mode
    public enum GameMode {Endless, Level}
    public GameMode CurrentGameMode { get; set; }

    [Header("Level Settings")]
    public int currentLevel = 0;
    public GameObject[] levelPrefabs;
    
    [Header("Player Settings")]
    public bool canDash = false;
    public bool fastFall = false;

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            SpawnLevel();
        }
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
    
    private void SpawnLevel()
    {
        if (CurrentGameMode == GameMode.Level && currentLevel > 0 && currentLevel <= levelPrefabs.Length)
        {
            Debug.Log("test");
            GameObject levelPrefab = levelPrefabs[currentLevel - 1];
            Instantiate(levelPrefab);
        }
        else if (CurrentGameMode == GameMode.Endless)
        {
            //shit für endless mode spawnen lassen
        }
    }
    
    public void StartLevel(int level)
    {
        CurrentGameMode = GameMode.Level;
        currentLevel = level;

        if (level >= 5 && level < 10)
        {
            canDash = true;
            fastFall = false;
        }
        else if (level >= 10)
        {
            canDash = true;
            fastFall = true;
        }

        SceneManager.LoadScene(1);
    }
    
    public void StartEndlessMode()
    {
        CurrentGameMode = GameMode.Endless;
        currentLevel = 0;
        canDash = true;
        fastFall = true;

        SceneManager.LoadScene(1);
    }
}