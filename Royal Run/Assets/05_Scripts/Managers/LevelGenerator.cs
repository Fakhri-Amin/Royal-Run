using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private PlayerEventSO playerEventSO;
    [SerializeField] private List<Chunk> chunkPrefabs = new();
    [SerializeField] private Transform chunkParent;
    [SerializeField] private int startingChunkAmount = 12;
    [SerializeField] private float chunkLength = 10f;

    private readonly List<Chunk> chunks = new List<Chunk>();
    private List<int> angles = new List<int> { 0, 180 };

    private void Start()
    {
        SpawnInitialChunks();
    }

    private void OnEnable()
    {
        if (playerEventSO != null)
            playerEventSO.Event.OnChunkDestroyed += HandleChunkDestroyed;
    }

    private void OnDisable()
    {
        if (playerEventSO != null)
            playerEventSO.Event.OnChunkDestroyed -= HandleChunkDestroyed;
    }

    private void HandleChunkDestroyed(Chunk chunk)
    {
        if (chunks.Contains(chunk))
        {
            chunks.Remove(chunk);
            Destroy(chunk.gameObject); // Destroy the old chunk
        }

        SpawnNewChunk();
    }

    private void SpawnInitialChunks()
    {
        Vector3 spawnPosition = transform.position;

        for (int i = 0; i < startingChunkAmount; i++)
        {
            SpawnChunkAtPosition(spawnPosition);
            spawnPosition += Vector3.forward * chunkLength;
        }
    }

    private void SpawnNewChunk()
    {
        if (chunks.Count == 0) return;

        Vector3 lastChunkPosition = chunks[chunks.Count - 1].transform.position;
        Vector3 spawnPosition = lastChunkPosition + Vector3.forward * chunkLength;

        SpawnChunkAtPosition(spawnPosition);
    }

    private void SpawnChunkAtPosition(Vector3 position)
    {
        Chunk randomChunk = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
        Chunk newChunk = Instantiate(randomChunk, position, Quaternion.identity, chunkParent);
        newChunk.Initialize(chunkLength);
        chunks.Add(newChunk);
    }
}
