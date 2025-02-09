using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float hitCooldown = 1f;
    const string hitString = "Hit";

    private float currentCooldown;

    private void Start()
    {
        currentCooldown = hitCooldown;
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (currentCooldown <= 0)
        {
            animator.SetTrigger(hitString);
            currentCooldown = hitCooldown;
        }
    }
}
