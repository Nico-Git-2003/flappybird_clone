using UnityEngine;

public enum UpgradeType
{
    DashForce,
    DashCooldown,
    DashTime,
    Jump,
    Speed,
    Fall
}

[CreateAssetMenu(fileName = "UpgradeInfo", menuName = "Scriptable Objects/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite  upgradeIcon;
    public string upgradeDescription;
    public UpgradeType upgradeType;
}
