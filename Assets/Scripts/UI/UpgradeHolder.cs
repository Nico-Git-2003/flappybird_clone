using System;
using TMPro;
using UnityEngine;

public class UpgradeHolder : MonoBehaviour
{
    public Upgrade upgrade;

    public TMP_Text upgradeNameText;
    public Sprite  upgradeIcon;
    public TMP_Text upgradeDescriptionText;

    private void Start()
    {
        if (upgrade != null)
        {
            upgradeNameText.text = upgrade.upgradeName;
            upgradeDescriptionText.text = upgrade.upgradeDescription;
        }
    }

    public void UseUpgrade()
    {
        PlayerUpgradeHandler playerUpgradeHandler = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerUpgradeHandler>();
        playerUpgradeHandler.Upgrade(upgrade);
    }
}
