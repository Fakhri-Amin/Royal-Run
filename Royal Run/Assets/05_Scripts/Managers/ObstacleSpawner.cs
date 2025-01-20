using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float xPosition = 3;
    [SerializeField] private float spawnTime = 1f;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            float randomXPosition = Random.Range(-xPosition, xPosition);

            Instantiate(obstacle, new Vector3(randomXPosition, 2, 24), transform.rotation);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
