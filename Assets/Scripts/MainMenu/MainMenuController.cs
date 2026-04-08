using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject startSection;
    public GameObject levelSelection;

    public List<Button> levelSelectionButtons;

    private void Start()
    {
        startSection.SetActive(true);
        levelSelection.SetActive(false);
        
        AddListenerToLevelButtons();
    }

    public void OpenLevelSelection()
    {
        startSection.SetActive(false);
        levelSelection.SetActive(true);
    }

    public void BackToStartSection()
    {
        levelSelection.SetActive(false);
        startSection.SetActive(true);
    }

    public void StartEndlessMode()
    {
        GameManager.Instance.StartEndlessMode();
    }

    public void AddListenerToLevelButtons()
    {
        for (int i = 0; i < levelSelectionButtons.Count; i++)
        {
            int levelIndex = i + 1;

            levelSelectionButtons[i].onClick.RemoveAllListeners();
            levelSelectionButtons[i].onClick.AddListener(() => GameManager.Instance.StartLevel(levelIndex));
        }
    }
    
}
