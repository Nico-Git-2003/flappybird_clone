using System;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject upgradeMenu;

    private void Update()
    {
        if(GameManager.Instance.CurrentState == GameManager.GameState.GameOver) EnableGameOverMenu();
        else if (GameManager.Instance.CurrentState == GameManager.GameState.Upgrade) EnableUpgradeMenu();
    }

    void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    
    void EnableUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
    }
    
    void DisableUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
    }
}
