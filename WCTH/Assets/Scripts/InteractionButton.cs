using UnityEngine;

public class InteractionButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Transform player;

    public float spacing = 1.4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        animator.Play("Speak");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithPlayer();
    }
    void MoveWithPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y + spacing, player.position.z);
    }
}
