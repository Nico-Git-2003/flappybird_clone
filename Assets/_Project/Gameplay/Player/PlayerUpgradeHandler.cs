using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerUpgradeHandler : MonoBehaviour
{
    public List<Upgrade> upgrades = new List<Upgrade>();
    
    public GameObject upgradePrefab;
    public GameObject upgradeMenu;
    
    private int currentScore;
    private int lastUpgradeScore;

    private void Update()
    {
        currentScore = GameManager.Instance.Score;

        if (currentScore % 5 == 0 && currentScore != 0 && currentScore != lastUpgradeScore)
        {
            lastUpgradeScore = currentScore;

            GameManager.Instance.CurrentState = GameManager.GameState.Upgrade;
            CreateUpgrades();
        }
    }

    void CreateUpgrades()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject upgrade = Instantiate(upgradePrefab, upgradeMenu.transform);
            upgrade.GetComponent<UpgradeHolder>().upgrade = upgrades[Random.Range(0, upgrades.Count)];
        }
    }
}
