using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    //prefab für pipe
    public GameObject pipePrefab;

    /*mindest- und maximalabstand zwischen pipes
     abstand zwischen pipes (übereinander)
     abstand zwischen pipes (nebeneinander)
     */

    public int gapX = 7;
    
    public int pipeGapMinTop = 16;
    public int pipeGapMaxTop = 8;
    public int pipeGapMinBot = -16;
    public int pipeGapMaxBot = -8;

    private void Start()
    {
        SpawnPipe();
    }

    void SpawnPipe()
    {
        for (int i = 0; i < 20; i++)
        {
            float offsetTop =  Random.Range(pipeGapMinTop, pipeGapMaxTop);
            float offsetBot = Random.Range(pipeGapMinBot, pipeGapMaxBot);
            
            GameObject pipe1 = Instantiate(pipePrefab, new Vector3(transform.position.x + i * gapX, offsetTop, 0), Quaternion.identity);
            GameObject pipe2 = Instantiate(pipePrefab, new Vector3(transform.position.x + i * gapX, offsetBot, 0), Quaternion.identity);   
        }
    }
}
