using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] float jumpPower = 9f;
    [SerializeField] float fallingGravityScale = 2.5f;
    [SerializeField] float baseGravityScale = 1.5f;

    private Rigidbody2D rb;
    bool isGrounded;
    byte jumpCounter;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = baseGravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1f, 0.3f), 0,groundLayer); //checks if a nonexistent collider overlaps the "Ground" Layer
        if(isGrounded) //double jump
        {
            jumpCounter = 1;
            rb.gravityScale = baseGravityScale;
        }

        if (Input.GetButtonDown("Jump") && jumpCounter > 0)
        {
            jumpCounter--;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (rb.velocity.y < 0) //change gravity during fall for more satisfying jump
        {
            rb.gravityScale = fallingGravityScale;
        }
        else
        {
            rb.gravityScale = baseGravityScale;
        }
    }
}
