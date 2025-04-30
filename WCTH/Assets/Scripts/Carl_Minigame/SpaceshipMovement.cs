using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private InputDevice inputDevice;
    private Vector2 moveInput;

    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        InputSystem.onActionChange += OnActionChange;
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        // Clamp spaceship position to screen bounds
        Vector3 pos = transform.position;

        // Get screen bounds in world coordinates
        Vector3 minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // Optionally account for sprite size:
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        float halfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;

        pos.x = Mathf.Clamp(pos.x, minScreenBounds.x + halfWidth, maxScreenBounds.x - halfWidth);
        pos.y = Mathf.Clamp(pos.y, minScreenBounds.y + halfHeight, maxScreenBounds.y - halfHeight);

        transform.position = pos;
    }

    private void OnActionChange(object obj, InputActionChange change)
    {
        if (change == InputActionChange.ActionPerformed)
        {
            var inputAction = (InputAction)obj;
            var lastControl = inputAction.activeControl;
            inputDevice = lastControl.device;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
