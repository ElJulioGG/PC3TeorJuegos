using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] objectsToSpawn; 
    public Transform spawnPoint;        
    public float spawnInterval = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomObject), 0f, spawnInterval);
    }

    void SpawnRandomObject()
    {
        if (objectsToSpawn.Length == 0) return;

        int index = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[index], spawnPoint.position, Quaternion.identity);
    }
}
