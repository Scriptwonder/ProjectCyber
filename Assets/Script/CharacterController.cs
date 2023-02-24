using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform groundCheck;
    public float groundRadius = 0.2f;

    public float speed = 10f;
    private float moveHorizontal;

    private bool isDashing = false;
    public float dashForce = 500f;
    public float dashDuration = 0.5f;
    public float dashTime;
    private bool isJumping = false;
    public float jumpForce = 500f;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, 5);
        moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isJumping = true;
            isGrounded = false;
        }

        if (isDashing && Time.time >= dashTime)
        {
            isDashing = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (isGrounded)
        {
            isJumping = false;
        }
    }

    public void doubleJump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
        //animations TODO
    }

    public void dash()
    {
        isDashing = true;
        dashTime = Time.time + dashDuration;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(moveHorizontal * dashForce, jumpForce));
        //play animation TODO
    }

    // This method is called when the ground check object enters a trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 5)
        {
            isGrounded = true;
        }
    }

    // This method is called when the ground check object exits a trigger collider
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 5)
        {
            isGrounded = false;
        }
    }
}
