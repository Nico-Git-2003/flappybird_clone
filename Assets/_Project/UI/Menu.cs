using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void Update()
    {
        if(GameManager.Instance.CurrentState == GameManager.GameState.GameOver) EnableGameOverMenu();
    }

    void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
