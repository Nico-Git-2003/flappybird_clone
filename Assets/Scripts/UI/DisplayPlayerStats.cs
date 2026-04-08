using System;
using TMPro;
using UnityEngine;

public class DisplayPlayerStats : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private Player playerInfo;

    public TMP_Text statsText;
    
    private void Start()
    {
        playerInfo = player.GetComponent<Player>();
    }

    private void Update()
    {
        DisplayStats();
    }

    void DisplayStats()
    {
        if (GameManager.Instance.CurrentGameMode == GameManager.GameMode.Endless)
        {
            statsText.text = $"Dash Force: {playerInfo.dashForce} \nDash Cooldown: {playerInfo.dashCooldown} \nJump Force: {playerInfo.jumpForce} \nMove Speed: {playerInfo.moveSpeed} \nFall Speed: {playerInfo.fallSpeed} \nDash Time: {playerInfo.dashTime}";
        }
    }
}
