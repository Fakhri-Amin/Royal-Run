using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private float startingChunkAmount = 12;
    [SerializeField] private float chunkLength = 10;

    private GameObject[] chunks = new GameObject[12];

    void Start()
    {
        SpawnChunks();
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            GameObject newChunk = Instantiate(chunkPrefab, chunkPrefab.transform.position + Vector3.forward * chunkLength * i, Quaternion.identity, chunkParent);
            chunks[i] = newChunk;
        }
    }
}
