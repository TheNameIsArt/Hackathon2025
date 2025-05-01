using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class OfficeMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizonal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(input * speed, input * speed);
    }

    /*
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
    }*/

}
