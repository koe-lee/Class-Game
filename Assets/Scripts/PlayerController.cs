using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 movementInput;


    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext callBack) => movementInput = callBack.ReadValue<Vector2>();
}
 