using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles = new();
    [SerializeField] private float xSpawnPositionRange = 3;
    [SerializeField] private float ySpawnPosition = 2;
    [SerializeField] private float zSpawnPosition = 26;
    [SerializeField] private float spawnTime = 1f;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            float randomXPosition = Random.Range(-xSpawnPositionRange, xSpawnPositionRange);
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Count)];
            Instantiate(randomObstacle, new Vector3(randomXPosition, ySpawnPosition, zSpawnPosition), Random.rotation);
        }
    }
}
