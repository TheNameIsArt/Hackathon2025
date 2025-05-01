using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class OfficeMovement : MonoBehaviour
{

    public InputActionAsset inputActions;

    private InputAction m_moveActionGP;
    private InputAction m_moveActionKB;

    private Vector2 m_movement;
    private Animator m_animator;
    private Rigidbody2D m_Rigidbody;

    public float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        inputActions.FindActionMap("Office Movement").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Office Movement").Disable();
    }

    private void Awake()
    {
        m_moveActionGP = InputSystem.actions.FindAction("Movement");
        m_moveActionKB = InputSystem.actions.FindAction("klmMovement");

        m_animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    void Sidescrolling(InputAction.CallbackContext context)
    {
        m_movement = context.ReadValue<Vector2>();
    }
    
    void Animate()
    {
        if (m_movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (m_movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (m_movement.x != 0 || m_movement.y != 0)
        {
            m_animator.Play("Andy_Run");
        }
        else
        {
            m_animator.Play("Andy_Idle");
        }
    }

}
