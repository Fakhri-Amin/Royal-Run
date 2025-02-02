using UnityEngine;

public class PickUpItemCollisionHandler : MonoBehaviour
{
    [SerializeField] private PickUpType pickUpType;
    const string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Destroy(gameObject);
        }
    }
}
