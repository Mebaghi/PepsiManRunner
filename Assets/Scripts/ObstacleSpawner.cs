using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;   // ← این باعث میشه Array ببینی
    public Transform player;

    [Header("Lane Settings")]
    public float laneDistance = 2.5f;

    [Header("Spawn Settings")]
    public float spawnAheadDistance = 25f;
    public float minGap = 7f;
    public float maxGap = 12f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = player.position.z + 10f;
    }

    void Update()
    {
        if (player.position.z + spawnAheadDistance >= nextSpawnZ)
        {
            SpawnObstacle();
            nextSpawnZ += Random.Range(minGap, maxGap);
        }
    }

    void SpawnObstacle()
    {
        int laneIndex = Random.Range(0, 3);
        float xPos = (laneIndex - 1) * laneDistance;

        int randomIndex = Random.Range(0, obstacles.Length);
        GameObject chosenObstacle = obstacles[randomIndex];

        Vector3 spawnPos = new Vector3(xPos, 0.5f, nextSpawnZ);
        Instantiate(chosenObstacle, spawnPos, Quaternion.identity);
    }
}
