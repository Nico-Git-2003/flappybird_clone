using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject player = other.gameObject;
        
        if (player.GetComponent<Player>() != null)
        {
            Destroy(player);
        }
    }
}
