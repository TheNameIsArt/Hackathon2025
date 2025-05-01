using UnityEngine;

public class Scr_NPCController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip botAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(botAnimation.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
