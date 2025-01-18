using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerEventSO PlayerEventSO;

    private Vector2 movement;

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        PlayerEventSO.Event.OnPlayerMove.Invoke(movement);
    }
}
