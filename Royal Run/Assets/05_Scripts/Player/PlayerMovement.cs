using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    [Header("Movement Clamp")]
    [SerializeField] private float xClamp = 3.6f;
    [SerializeField] private float zClamp = 2f;

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
        Vector3 newPosition = rigidBody.position + moveSpeed * Time.fixedDeltaTime * new Vector3(movement.x, 0f, movement.y);
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, 0, zClamp);
        rigidBody.MovePosition(newPosition);
    }

    private void HandleMove(Vector3 movement)
    {
        this.movement = movement;
    }

}
