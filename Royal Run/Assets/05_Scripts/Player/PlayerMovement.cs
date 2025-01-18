using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    private PlayerEventSO playerEventSO;
    private Rigidbody rigidBody;
    private Vector3 movement;

    private void Awake()
    {
        playerEventSO = GetComponent<PlayerController>().PlayerEventSO;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerEventSO.Event.OnPlayerMove += HandleMove;
    }

    private void OnDisable()
    {
        playerEventSO.Event.OnPlayerMove -= HandleMove;
    }

    private void FixedUpdate()
    {
        if (movement == Vector3.zero) return;

        rigidBody.MovePosition(rigidBody.position + moveSpeed * Time.fixedDeltaTime * new Vector3(movement.x, 0f, movement.y));
    }

    private void HandleMove(Vector3 movement)
    {
        this.movement = movement;
    }

}
