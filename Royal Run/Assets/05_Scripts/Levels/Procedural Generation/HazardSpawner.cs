using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] hazardPrefabs;
    [SerializeField] private float spawnYOffset;
    [SerializeField] private float hazardAnglesOffset = 10f;

    private Chunk chunk;
    private GameObject spawnedHazard;

    private void Awake()
    {
        chunk = GetComponent<Chunk>();
    }

    private void Start()
    {
        SpawnHazard();
    }

    private void SpawnHazard()
    {
        int fenceToSpawn = Random.Range(0, chunk.Lanes.Length);

        for (int i = 0; i < fenceToSpawn; i++)
        {
            if (chunk.IsAvailableLaneEmpty()) break;

            int selectedLane = chunk.SelectLane();

            Vector3 spawnPosition = new Vector3(chunk.Lanes[selectedLane], transform.position.y + spawnYOffset, transform.position.z);

            GameObject randomHazard = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];

            float randomAngle = Random.Range(-hazardAnglesOffset, hazardAnglesOffset);
            spawnedHazard = Instantiate(randomHazard, spawnPosition, Quaternion.Euler(new Vector3(0, randomAngle, 0)), transform);
        }
    }

    public void ClearHazard()
    {
        spawnedHazard = null;
        Destroy(spawnedHazard);
    }
}
