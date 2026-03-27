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
}
