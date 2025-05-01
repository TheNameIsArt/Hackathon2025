using DialogueEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scr_PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public InputDevice inputDevice;

    private bool isConversationZone;
    private bool isInteractionZone;
    private string targetSceneName;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject interactionZone;
    private PlayerInput playerInput;
    private GameObject interactionButton;
    private GameObject speechButton;

    [SerializeField] private bool isConversationActive = false;
    [SerializeField] Button ConversationButton;

    private ConversationEditer conversationEditor; // Reference to the ConversationEditor

    private GameObject detectiveMode; // Reference to the "Detective Mode" GameObject

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        interactionButton = GameObject.FindGameObjectWithTag("InteractionButton");
        speechButton = GameObject.FindGameObjectWithTag("SpeechButton");

        Debug.Log("PlayerController Awake: Initialized components.");
    }

    void Start()
    {
        InputSystem.onActionChange += OnActionChange;
        if (interactionButton != null)
        {
            interactionButton.SetActive(false);
        }
        playerInput = GetComponent<PlayerInput>();

        Debug.Log("PlayerController Start: Interaction button hidden and PlayerInput initialized.");
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        Animate();

        if (ConversationManager.Instance != null)
        {
            if (!ConversationManager.Instance.IsConversationActive && !playerInput.enabled)
            {
                playerInput.enabled = true; // Enable the PlayerInput component
                Debug.Log("PlayerController Update: Conversation ended, PlayerInput re-enabled.");
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log($"PlayerController Move: Move input received - {moveInput}");
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
            //Debug.Log("PlayerController Animate: Player is running.");
        }
        else
        {
            animator.Play("Andy_Idle");
            //Debug.Log("PlayerController Animate: Player is idle.");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        interactionZone = collision.gameObject;

        if (collision.gameObject.tag == "InteractionZone")
        {
            isInteractionZone = true;
            interactionButton.SetActive(true);
            interactionButton.GetComponent<InteractionButton>().lookSprite = true;
            detectiveMode = interactionZone.GetComponent<InteractionZone>().detectiveMode;

            Debug.Log("PlayerController OnTriggerStay2D: Entered InteractionZone.");

            // Enable "Detective Mode" when in the InteractionZone
            if (detectiveMode != null)
            {
                detectiveMode.SetActive(true);
                Debug.Log("PlayerController OnTriggerStay2D: Detective Mode enabled.");
            }
        }
        else if (collision.gameObject.tag == "ConversationZone")
        {
            conversationEditor = interactionZone.GetComponent<ConversationEditer>();
            isConversationZone = true;
            if (!isConversationActive)
            {
                speechButton.SetActive(true);
                speechButton.GetComponent<InteractionButton>().talkSprite = true;
                ConversationButton.interactable = true;
                Debug.Log("PlayerController OnTriggerStay2D: Entered ConversationZone.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactionButton != null)
        {
            if (collision.gameObject.tag == "InteractionZone" || collision.gameObject.tag == "ConversationZone")
            {
                interactionButton.SetActive(false);
                speechButton.SetActive(false);
                isInteractionZone = false;
                isConversationZone = false;
                interactionButton.GetComponent<InteractionButton>().lookSprite = false;
                speechButton.GetComponent<InteractionButton>().talkSprite = false;
                ConversationButton.interactable = false;

                Debug.Log("PlayerController OnTriggerExit2D: Exited InteractionZone or ConversationZone.");

                // Disable "Detective Mode" when exiting the InteractionZone
                if (collision.gameObject.tag == "InteractionZone" && detectiveMode != null)
                {
                    detectiveMode.SetActive(false);
                    Debug.Log("PlayerController OnTriggerExit2D: Detective Mode disabled.");
                }
            }
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (interactionButton != null)
        {
            if (context.performed && isInteractionZone)
            {
                Debug.Log("PlayerController Interact: Interaction performed in InteractionZone.");
            }
            else if (context.performed && isConversationZone)
            {
                if (conversationEditor != null)
                {
                    conversationEditor.PlayConversation();
                    Debug.Log("PlayerController Interact: Conversation started.");
                }
                else
                {
                    Debug.LogWarning("PlayerController Interact: ConversationEditor component not found on the GameObject.");
                }
                playerInput.enabled = false; // Disable the PlayerInput component
                interactionButton.SetActive(false); // Hide the interaction button
            }
        }
    }

    private void OnActionChange(object obj, InputActionChange change)
    {
        if (change == InputActionChange.ActionPerformed)
        {
            var inputAction = (InputAction)obj;
            var lastControl = inputAction.activeControl;
            inputDevice = lastControl.device;

            //Debug.Log($"PlayerController OnActionChange: Input action performed - {inputAction.name}, Device - {inputDevice.name}");
        }
    }
}

