using System;
using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    public bool isSpecial = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isSpecial)
        {
            GameManager.Instance.AddScore(1);
            float xPos = transform.position.x + PipeSpawner.Instance.pipeGapX * 3;
            PipeSpawner.Instance.SpawnPipes(6, xPos);
        }
        else if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1);
        }
    }

    private void Update()
    {
        Destroy(gameObject,60);
    }
}
