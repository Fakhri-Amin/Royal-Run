using UnityEngine;

public class ObstacleCollisionHandler : MonoBehaviour
{
    [SerializeField] private ObstacleType obstacleType;
    const string obstacleDestroyerTag = "ObstacleDestroyer";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(obstacleDestroyerTag))
        {
            GameObjectPool.Instance.ReturnToPool(obstacleType, gameObject);
        }

    }
}
