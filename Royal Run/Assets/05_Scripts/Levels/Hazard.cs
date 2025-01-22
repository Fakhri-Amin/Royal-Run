using System.Collections;
using UnityEditor.Search;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private GameObject[] hazardPrefabs;
    [SerializeField] private float spawnYOffset;
    [SerializeField] private float[] lanes = { -2.8f, 0, 2.8f };
    [SerializeField] private float hazardAnglesOffset = 10f;

    private void Start()
    {
        SpawnHazard();
    }

    private void SpawnHazard()
    {
        float randomXPosition = lanes[Random.Range(0, lanes.Length)];
        Vector3 spawnPosition = new Vector3(randomXPosition, transform.position.y + spawnYOffset, transform.position.z);

        GameObject randomHazard = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];

        float randomAngle = Random.Range(-hazardAnglesOffset, hazardAnglesOffset);
        Instantiate(randomHazard, spawnPosition, Quaternion.Euler(new Vector3(0, randomAngle, 0)), transform);
    }
}
