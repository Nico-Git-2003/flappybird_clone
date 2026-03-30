using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerUpgradeHandler : MonoBehaviour
{
    public List<Upgrade> upgrades = new List<Upgrade>();
    
    public GameObject upgradePrefab;
    public GameObject upgradeMenu;

    private Player playerScript;
    
    private int currentScore;
    private int lastUpgradeScore;

    public int dashForceLevel;
    public int dashCooldownLevel;
    public int jumpLevel;
    public int speedLevel;

    private float dashForceUpgradeMultiplier = 0.25f;
    private float dashCooldownUpgradeMultiplier = 0.1f;
    private float jumpUpgradeMultiplier = 0.25f;
    private float moveUpgradeMultiplier = 0.2f;

    private List<GameObject> upgradePrefabs = new List<GameObject>();
    
    private void Start()
    {
        playerScript = GetComponent<Player>();
    }

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
            upgradePrefabs.Add(upgrade);
            upgrade.GetComponent<UpgradeHolder>().upgrade = upgrades[Random.Range(0, upgrades.Count)];
        }
    }

    public void Upgrade(Upgrade upgrade)
    {
        if (upgrade != null)
        {
            if (upgrade.upgradeType == UpgradeType.DashCooldown)
            {
                dashCooldownLevel++;
            }
            else if (upgrade.upgradeType == UpgradeType.DashForce)
            {
                dashForceLevel++;
            }
            else if (upgrade.upgradeType == UpgradeType.Jump)
            {
                jumpLevel++;
            }
            else if (upgrade.upgradeType == UpgradeType.Speed)
            {
                speedLevel++;
            }

            ApplyUpgrades();
        }
    }
    
    void ApplyUpgrades()
    {
        playerScript.dashForce = playerScript.baseDashForce + dashForceLevel * dashForceUpgradeMultiplier;

        playerScript.dashCooldown = playerScript.baseDashCooldown - dashCooldownLevel * dashCooldownUpgradeMultiplier;

        playerScript.jumpForce = playerScript.baseJumpForce + jumpLevel * jumpUpgradeMultiplier;

        playerScript.moveSpeed = playerScript.baseMoveSpeed + speedLevel * moveUpgradeMultiplier;

        for (int i = 0; i < upgradePrefabs.Count; i++)
        {
            Destroy(upgradePrefabs[i].gameObject);
        }
        upgradePrefabs.Clear();
        GameManager.Instance.CurrentState = GameManager.GameState.Playing;
    }
}
