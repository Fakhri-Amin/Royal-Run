using UnityEngine;

public class ChunkMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4;

    private Chunk chunk;
    private HazardSpawner hazardSpawner;

    private void Awake()
    {
        chunk = GetComponent<Chunk>();
        hazardSpawner = GetComponent<HazardSpawner>();
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * (moveSpeed * Time.deltaTime));

        if (transform.position.z <= Camera.main.transform.position.z - chunk.ChunkLength)
        {
            chunk.PlayerEventSO.Event.OnChunkDestroyed(chunk);
            Destroy(gameObject);
        }
    }
}
