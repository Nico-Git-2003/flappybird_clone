using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    //Game State
    public enum GameState { Playing, Paused, GameOver, Upgrade, Menu, LevelFinished }
    public GameState CurrentState { get; set; }
    
    //Game Mode
    public enum GameMode {Endless, Level}
    public GameMode CurrentGameMode { get; set; }

    [Header("Level Settings")]
    public int currentLevel = 0;
    public GameObject[] levelPrefabs;
    public float levelTimer = 0;
    
    [Header("Player Settings")]
    public bool canDash = false;
    public bool fastFall = false;

    public int Score { get; private set; }

    [Header("Endless Settings")] 
    public GameObject PipeSpawner;

    [Header("UI Settings")] 
    public GameObject CanvasGameObject;
    
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

    private void Update()
    {
        if(CurrentGameMode ==  GameMode.Level) levelTimer += Time.deltaTime;
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

    public void PlayAgain()
    {
        GameManager.Instance.CurrentState =  GameManager.GameState.Playing;
        ResetScore();
        SceneManager.LoadScene(1);
        GameManager.Instance.levelTimer = 0;
    }
    
    private void SpawnLevel()
    {
        if (CurrentGameMode == GameMode.Level && currentLevel > 0 && currentLevel <= levelPrefabs.Length)
        {
            GameObject levelPrefab = levelPrefabs[currentLevel - 1];
            Instantiate(levelPrefab);
        }
        else if (CurrentGameMode == GameMode.Endless)
        {
            Debug.Log("Test");
            Instantiate(PipeSpawner);
        }

        Instantiate(CanvasGameObject);
    }

    public void ResetScore()
    {
        Score = 0;
    }
    
    public void StartLevel(int level)
    {
        levelTimer = 0;
        canDash = false;
        fastFall = false;
        
        CurrentState = GameState.Playing;
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
        CurrentState = GameState.Playing;
        CurrentGameMode = GameMode.Endless;
        currentLevel = 0;
        canDash = true;
        fastFall = true;

        SceneManager.LoadScene(1);
    }
}