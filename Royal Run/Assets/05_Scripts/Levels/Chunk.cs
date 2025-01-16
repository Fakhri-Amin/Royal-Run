using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private PlayerEventSO playerEventSO;

    private float chunkLength;

    public PlayerEventSO PlayerEventSO => playerEventSO;
    public float ChunkLength => chunkLength;

    public void Initialize(float chunkLength)
    {
        this.chunkLength = chunkLength;
    }
}
