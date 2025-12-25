using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;

    [Header("Lane Settings")]
    public float laneDistance = 2.5f;

    [Header("Spawn Settings")]
    public float spawnAheadDistance = 25f;
    public float minGap = 3f;
    public float maxGap = 7f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = player.position.z + 10f;
    }

    void Update()
    {
        // اگر بازی تمام شده، مانع جدید نساز
        if (player == null)
            return;

        if (player.position.z + spawnAheadDistance >= nextSpawnZ)
        {
            SpawnObstacle();
            nextSpawnZ += Random.Range(minGap, maxGap);
        }
    }

    void SpawnObstacle()
    {
        int laneIndex = Random.Range(0, 3); // 0,1,2
        float xPos = (laneIndex - 1) * laneDistance;

        Vector3 spawnPosition = new Vector3(xPos, 0.5f, nextSpawnZ);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
