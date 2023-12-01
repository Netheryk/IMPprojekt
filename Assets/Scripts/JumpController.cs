using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] float jumpPower = 9f;
    [SerializeField] float fallingGravityScale = 2.5f;

    private Rigidbody2D rb;
    bool isGrounded;
    int jumpsLeft;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1f, 0.3f), 0,groundLayer); //checks if a nonexistent collider overlaps the "Ground" Layer
        if(isGrounded) //double jump
        {
            jumpsLeft = 1;
        }

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            jumpsLeft--;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (rb.velocity.y < 0) //change gravity during fall for more satisfying jump
        {
            rb.gravityScale = fallingGravityScale;
        }
        else
        {
            rb.gravityScale = 1.5f;
        }
    }
}
