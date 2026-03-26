using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject scoreColliderPrefab;

    public int gapX = 7;
    public int pipeGapMin = 16; //the smaller this value, the closer the pipes will get -> game gets harder
    public int pipeGapMax = 8;

    private void Start()
    {
        SpawnPipe();
    }

    void SpawnPipe()
    {
        GameObject pipeParent = new  GameObject("Pipes");
        
        //TODO a specific amount of pipes will spawn depending on the player socore -> for example every third score new pipes will spawn. this way its endless
        for (int i = 0; i < 20; i++)
        {
            int offsetTop =  Random.Range(pipeGapMin, pipeGapMax);
            int offsetBot = -Random.Range(pipeGapMin, pipeGapMax);

            float xPosition = transform.position.x + i * gapX;
            
            GameObject pipeTop = Instantiate(pipePrefab, new Vector3(xPosition, offsetTop, 0), Quaternion.identity, pipeParent.transform);
            GameObject pipeBot = Instantiate(pipePrefab, new Vector3(xPosition, offsetBot, 0), Quaternion.identity, pipeParent.transform); 
            
            int scoreColliderYPosition = offsetTop / offsetBot;
            GameObject scoreCollider = Instantiate(scoreColliderPrefab, new Vector3(xPosition, scoreColliderYPosition, 0), Quaternion.identity, pipeParent.transform);
        }
    }
}
