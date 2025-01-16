using UnityEngine;

public class ChunkMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4;

    void Update()
    {
        transform.Translate(-Vector3.forward * (moveSpeed * Time.deltaTime));
    }
}
