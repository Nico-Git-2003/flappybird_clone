using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject upgradeMenu;
    public GameObject levelFinishedMenu;

    public GameObject scoreGameObject;

    public TMP_Text finalScoreText;
    public TMP_Text levelFinishedTimeText;
    
    private void Update()
    {
        GameManager gameManager = GameManager.Instance;

        switch (gameManager.CurrentState)
        {
            case GameManager.GameState.GameOver:
                EnableGameOverMenu();
                break;
            case GameManager.GameState.Upgrade:
                EnableUpgradeMenu();
                break;
            case GameManager.GameState.LevelFinished:
                EnableLevelFinishedMenu();
                break;
        }
        
        switch (gameManager.CurrentGameMode)
        {
            case GameManager.GameMode.Level:
                scoreGameObject.SetActive(false);
                break;
            case GameManager.GameMode.Endless:
                scoreGameObject.SetActive(true);
                break;
        }
        
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        finalScoreText.text = $"Highscore: {GameManager.Instance.Score.ToString()}";
    }
    
    public void DisableGameOverMenu()
    {
        gameOverMenu.SetActive(false);
    }

    public void DisableLevelFinishedMenu()
    {
        levelFinishedMenu.SetActive(false);
    }
    
    public void EnableUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
    }
    
    public void DisableUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
    }

    public void EnableLevelFinishedMenu()
    {
        levelFinishedMenu.SetActive(true);
        float finishedTime = GameManager.Instance.levelTimer;
        levelFinishedTimeText.text = $"Youre Time: {finishedTime.ToString()}";
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.ResetScore();
        GameManager.Instance.CurrentState = GameManager.GameState.Menu;
    }
}
