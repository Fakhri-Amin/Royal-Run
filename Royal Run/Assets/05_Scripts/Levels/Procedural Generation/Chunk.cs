using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public float[] Lanes = { -3, 0, 3 };
    [SerializeField] private PlayerEventSO playerEventSO;
    [SerializeField] private ChunkType chunkType;

    private readonly List<int> availableLanes = new List<int>() { 0, 1, 2 };
    private float chunkLength;

    public PlayerEventSO PlayerEventSO => playerEventSO;
    public float ChunkLength => chunkLength;
    public ChunkType ChunkType => chunkType;

    public void Initialize(float chunkLength)
    {
        this.chunkLength = chunkLength;
    }

    public int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

    public float[] GetLanes() => Lanes;

    public bool IsAvailableLaneEmpty()
    {
        return availableLanes.Count <= 0;
    }
}
