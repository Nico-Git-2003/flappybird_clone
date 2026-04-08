using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DamageSource"))
        {
            player.Die();
        }
        else if (other.CompareTag("WinZone"))
        {
            GameManager.Instance.CurrentState = GameManager.GameState.LevelFinished;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DamageSource"))
        {
            player.Die();
        }
    }
}
