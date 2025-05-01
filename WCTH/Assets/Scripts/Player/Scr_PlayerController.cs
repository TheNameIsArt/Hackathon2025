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


    }

    void Start()
    {
        InputSystem.onActionChange += OnActionChange;
        if (interactionButton != null)
        {
            interactionButton.SetActive(false);
        }
        playerInput = GetComponent<PlayerInput>();
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
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        interactionZone = collision.gameObject;

        if (collision.gameObject.tag == "InteractionZone")
        {
            isInteractionZone = true;
            interactionButton.SetActive(true);
            interactionButton.GetComponent<InteractionButton>().lookSprite = true;
            detectiveMode = interactionZone.GetComponent<InteractionZone>().detectiveMode;


            // Enable "Detective Mode" when in the InteractionZone
            if (detectiveMode != null)
            {
                detectiveMode.SetActive(true);
            }
        }
        else if (collision.gameObject.tag == "ConversationZone")
        {
            conversationEditor = interactionZone.GetComponent<ConversationEditer>();
            isConversationZone = true;
            if (!isConversationActive)
                speechButton.SetActive(true);
                speechButton.GetComponent<InteractionButton>().talkSprite = true;
                ConversationButton.interactable = true; 
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

                // Disable "Detective Mode" when exiting the InteractionZone
                if (collision.gameObject.tag == "InteractionZone" && detectiveMode != null)
                {
                    detectiveMode.SetActive(false);
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
                Debug.Log("INTERACT!");
            }
            else if (context.performed && isConversationZone)
            {
                if (conversationEditor != null)
                {
                    conversationEditor.PlayConversation();
                    Debug.Log("Conversation started!");
                }
                else
                {
                    Debug.LogWarning("ConversationEditor component not found on the GameObject.");
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
        }
    }
}

