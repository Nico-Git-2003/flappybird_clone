using UnityEngine;

public enum UpgradeType
{
    DashForce,
    DashCooldown,
    Jump,
    Speed
}

[CreateAssetMenu(fileName = "UpgradeInfo", menuName = "Scriptable Objects/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite  upgradeIcon;
    public string upgradeDescription;
    public UpgradeType upgradeType;
}
