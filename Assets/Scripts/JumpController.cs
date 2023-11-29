using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject groundCheckObj;
    bool isGrounded;

    [SerializeField] private float jumpPower = 9f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = groundCheckObj.GetComponent<GroundCheck>().isGrounded;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
