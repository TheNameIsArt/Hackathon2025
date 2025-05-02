using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Sidescroll : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;


    public float walkSpeed = 5f;

    private Vector2 moveInput;

    

    [SerializeField]
    private bool _isMoving = false;

    public bool isMoving
    {
        get => _isMoving;
        private set => _isMoving = value;
    }

    [SerializeField]
    private bool _isRunning = false;

    public bool isRunning
    {
        get => _isRunning;
        set => _isRunning = value;
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get => _isFacingRight;
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    private float CurrentMoveSpeed
    {
        get
        {
            if (isMoving)
            {
                return walkSpeed;
            }
            else
            {
                return 0;
            }
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isMoving = moveInput != Vector2.zero;
        Animate();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        isMoving = moveInput != Vector2.zero;
    }

    void Animate()
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

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
