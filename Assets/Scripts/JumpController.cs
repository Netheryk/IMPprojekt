using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] float jumpPower = 9f;

    private Rigidbody2D rb;
    bool isGrounded;
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower); //jump feels fine, should change gravity during fall so it feels better
        }
    }
}
