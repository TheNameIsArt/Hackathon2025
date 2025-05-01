using UnityEngine;

public class InteractionButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Transform playerPosition;
    private GameObject player;
    public bool lookSprite;
    public bool talkSprite;

    public float spacing = 1.4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookSprite = false;
        talkSprite = false;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithPlayer();
        
        if (lookSprite == true)
        {
            animator.Play("Look");
        }
        else if (talkSprite == true)
        {
            animator.Play("Speak");
        }
    }
    void MoveWithPlayer()
    {
        transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y + spacing, playerPosition.position.z);
    }
}
