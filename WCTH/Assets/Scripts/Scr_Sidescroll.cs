using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Sidescroll : MonoBehaviour
{
    // Reference to the Animator component (controls animations)
    private Animator animator;

    // Reference to the Rigidbody2D component (controls physics/movement)
    private Rigidbody2D rb;

    // Public speed value used to control walking speed
    public float walkSpeed = 5f;

    // Stores player movement input from Input System
    private Vector2 moveInput;

    // Serialized private variable for movement status (can be seen in Inspector)
    [SerializeField]
    private bool _isMoving = false;

    // Public read-only access to _isMoving; can only be changed inside this script
    public bool isMoving
    {
        get => _isMoving;
        private set => _isMoving = value;
    }

    // Serialized private variable for running state (can be seen and changed in Inspector)
    [SerializeField]
    private bool _isRunning = false;

    // Public property for getting and setting running state
    public bool isRunning
    {
        get => _isRunning;
        set => _isRunning = value;
    }

    // Public variable to track which direction the character is facing
    public bool _isFacingRight = true;

    // Property to flip the character sprite if direction changes
    public bool IsFacingRight
    {
        get => _isFacingRight;
        private set
        {
            if (_isFacingRight != value)
            {
                // Flip the character’s X scale to face opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    // Property that calculates the current move speed depending on movement state
    private float CurrentMoveSpeed
    {
        get
        {
            if (isMoving)
            {
                return walkSpeed; // Move at walking speed if moving
            }
            else
            {
                return 0; // Otherwise, no movement
            }
        }
    }

    // Called when the object is first initialized
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Called every frame
    void Update()
    {
        // Check if the player is trying to move
        isMoving = moveInput != Vector2.zero;

        // Handle animations based on input
        Animate();
    }

    // Called at a fixed time interval for physics updates
    private void FixedUpdate()
    {
        // Apply horizontal velocity based on input and current speed
        rb.linearVelocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.linearVelocity.y);
    }

    // Called when the move input action is triggered (from Input System)
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // Read movement input
        isMoving = moveInput != Vector2.zero;     // Update movement state
    }

    // Handles animation and sprite flipping
    void Animate()
    {
        // Flip character based on direction of movement
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }

        // Play running animation if moving, idle if not
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.Play("Andy_Run");
        }
        else
        {
            animator.Play("Andy_Idle");
        }
    }
}