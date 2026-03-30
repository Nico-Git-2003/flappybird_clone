using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject startSection;
    public GameObject levelSelection;

    private void Start()
    {
        startSection.SetActive(true);
        levelSelection.SetActive(false);
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
}
