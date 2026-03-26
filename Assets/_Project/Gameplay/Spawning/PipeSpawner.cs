using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    public static PipeSpawner Instance;
    
    public GameObject pipePrefab;
    public GameObject scoreColliderPrefab;
    
    public int pipeGapX = 7;
    
    public int topPipeSpawnMin; //the smaller this value, the closer the pipes will get -> game gets harder (16)
    public int topPipeSpawnMax; // 0
    public int pipeGapYMin;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        SpawnPipes(6, transform.position.x);
    }

    public void SpawnPipes(int amount, float x)
    {
        GameObject pipeParent = new  GameObject("Pipes");
        
        //TODO a specific amount of pipes will spawn depending on the player socore -> for example every third score new pipes will spawn. this way its endless
        for (int i = 0; i < amount; i++)
        {
            int offsetTop =  Random.Range(topPipeSpawnMin, topPipeSpawnMax + 1);
            int offsetBot = offsetTop - Random.Range(topPipeSpawnMax, topPipeSpawnMax + 2);
            
            float xPosition = x + i * pipeGapX;
            
            GameObject pipeTop = Instantiate(pipePrefab, new Vector3(xPosition, offsetTop, 0), Quaternion.identity, pipeParent.transform);
            GameObject pipeBot = Instantiate(pipePrefab, new Vector3(xPosition, offsetBot, 0), Quaternion.identity, pipeParent.transform); 
            
            int scoreColliderYPosition = (int)(pipeTop.transform.position.y + pipeBot.transform.position.y) / 2;
            GameObject scoreColliderGameObject = Instantiate(scoreColliderPrefab, new Vector3(xPosition, scoreColliderYPosition, 0), Quaternion.identity, pipeParent.transform);
            ScoreCollider sc = scoreColliderGameObject.GetComponent<ScoreCollider>();
            
            if (i != 0 && i % 3 == 0)
            {
                sc.isSpecial = true;
            }
        }
    }
}
