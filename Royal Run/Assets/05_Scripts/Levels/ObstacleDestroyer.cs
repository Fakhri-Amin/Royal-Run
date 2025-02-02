using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    const string obstacleTag = "Obstacle";

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(obstacleTag))
        {
            Destroy(other.gameObject);
        }
    }
}
