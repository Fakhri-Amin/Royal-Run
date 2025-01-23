using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public bool IsSpawnMultiple = false;
    [SerializeField] private GameObject collectableItemPrefab;
    [SerializeField] private float spawnYOffset;
    [SerializeField] private float hazardAnglesOffset = 10f;
    [SerializeField] private float spawnSpaceBetween = 3f;

    private Chunk chunk;

    private void Awake()
    {
        chunk = GetComponent<Chunk>();
    }

    private void Start()
    {
        if (IsSpawnMultiple)
        {
            SpawnMultipleCollectableItem();
        }
        else
        {
            SpawnSingleCollectableItem();
        }
    }

    private void SpawnSingleCollectableItem()
    {
        bool canSpawn = Random.value <= 0.3f;
        if (chunk.IsAvailableLaneEmpty() || !canSpawn) return;

        int selectedLane = chunk.SelectLane();

        Vector3 spawnPosition = new Vector3(chunk.Lanes[selectedLane], transform.position.y + spawnYOffset, transform.position.z);

        float randomAngle = Random.Range(-hazardAnglesOffset, hazardAnglesOffset);
        Instantiate(collectableItemPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, randomAngle, 0)), transform);
    }

    private void SpawnMultipleCollectableItem()
    {
        bool canSpawn = Random.value <= 0.5f;
        if (chunk.IsAvailableLaneEmpty() || !canSpawn) return;

        int selectedLane = chunk.SelectLane();

        int maxNumberToSpawn = 6;
        int numberToSpawn = Random.Range(1, maxNumberToSpawn);

        float topOfChunkZPosition = transform.position.z + (spawnSpaceBetween * 2f);

        for (int i = 0; i < numberToSpawn; i++)
        {
            float spawnZPosition = topOfChunkZPosition - (spawnSpaceBetween * i);

            Vector3 spawnPosition = new Vector3(chunk.Lanes[selectedLane], transform.position.y + spawnYOffset, spawnZPosition);

            float randomAngle = Random.Range(-hazardAnglesOffset, hazardAnglesOffset);
            Instantiate(collectableItemPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, randomAngle, 0)), transform);
        }
    }
}
