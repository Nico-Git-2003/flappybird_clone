using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public int gapX = 7;
    public int pipeGapMin = 16;
    public int pipeGapMax = 8;

    private void Start()
    {
        SpawnPipe();
    }

    void SpawnPipe()
    {
        for (int i = 0; i < 20; i++)
        {
            float offsetTop =  Random.Range(pipeGapMin, pipeGapMax);
            float offsetBot = -Random.Range(pipeGapMin, pipeGapMax);
            
            GameObject pipeTop = Instantiate(pipePrefab, new Vector3(transform.position.x + i * gapX, offsetTop, 0), Quaternion.identity);
            GameObject pipeBot = Instantiate(pipePrefab, new Vector3(transform.position.x + i * gapX, offsetBot, 0), Quaternion.identity);   
        }
    }
}
