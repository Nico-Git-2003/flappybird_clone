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
    public int dashTimeLevel;
    public int jumpLevel;
    public int speedLevel;
    public int fallLevel;

    private float dashForceUpgradeMultiplier = 0.25f;
    private float dashCooldownUpgradeMultiplier = 0.1f;
    private float dashTimeUpgradeMultiplier = 0.05f;
    private float jumpUpgradeMultiplier = 0.25f;
    private float moveUpgradeMultiplier = 0.2f;
    private float fallUpgradeMultiplier = 0.1f;

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
        List<Upgrade> avaiableUpgrades = new List<Upgrade>(upgrades);
        
        for (int i = 0; i < 3; i++)
        {
            GameObject upgradeGameObject = Instantiate(upgradePrefab, upgradeMenu.transform);
            upgradePrefabs.Add(upgradeGameObject);

            Upgrade upgrade = avaiableUpgrades[Random.Range(0, avaiableUpgrades.Count)];
            upgradeGameObject.GetComponent<UpgradeHolder>().upgrade = upgrade;
            avaiableUpgrades.Remove(upgrade);
        }
    }

    public void Upgrade(Upgrade upgrade)
    {
        if (upgrade != null)
        {
            switch (upgrade.upgradeType)
            {
                case UpgradeType.DashCooldown:
                    dashCooldownLevel++;
                    break;
                case UpgradeType.DashForce:
                    dashForceLevel++;
                    break;
                case UpgradeType.DashTime:
                    dashTimeLevel++;
                    break;
                case UpgradeType.Jump:
                    jumpLevel++;
                    break;
                case UpgradeType.Speed:
                    speedLevel++;
                    break;
                case  UpgradeType.Fall:
                    fallLevel++;
                    break;
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
        
        playerScript.fallSpeed = playerScript.baseFallSpeed + fallLevel * fallUpgradeMultiplier;
        
        playerScript.dashTime = playerScript.baseDashTime + dashTimeLevel * dashTimeUpgradeMultiplier;

        for (int i = 0; i < upgradePrefabs.Count; i++)
        {
            Destroy(upgradePrefabs[i].gameObject);
        }
        upgradePrefabs.Clear();
        GameManager.Instance.CurrentState = GameManager.GameState.Playing;
    }
}
