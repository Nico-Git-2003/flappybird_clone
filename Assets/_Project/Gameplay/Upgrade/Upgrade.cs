using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeInfo", menuName = "Scriptable Objects/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite  upgradeIcon;
    public string upgradeDescription;
}
