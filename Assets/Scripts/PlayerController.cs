using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField] float playerSpeed = 5f;
    Vector2 horizontalVector;
    float horizontalAxis;
    Rigidbody2D playerRb;

    //Dash
    [SerializeField] float dashSpeed = 10000f;
    [SerializeField] float dashLength = 3f;
    [SerializeField] float dashCooldown = 5f;
    bool canDash = true;
    bool isDashing = false;

    //jump and gravity control
    [SerializeField] float jumpPower = 7.5f;
    [SerializeField] float fallingGravityScale = 2.5f;
    [SerializeField] float baseGravityScale = 1.5f;
    bool isGrounded;
    byte jumpCounter;
    public Transform groundCheck;
    public LayerMask groundLayer;









    private void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.gravityScale = baseGravityScale;
    }

    public void Update()
    {
        //movement
        horizontalAxis = Input.GetAxisRaw("Horizontal");

        //Dash
        if (Input.GetKeyDown(KeyCode.Q) && (canDash == true)) //need to add cooldown
        {
            StartCoroutine(Dash());
        }

        if (isDashing) //disables jumping and gravity during dash
        {
            return;
        }

        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1f, 0.3f), 0, groundLayer); //checks if a created collider overlaps the "Ground" Layer
        if (isGrounded) //double jump
        {
            jumpCounter = 1;
            playerRb.gravityScale = baseGravityScale;
        }

        if (Input.GetButtonDown("Jump") && jumpCounter > 0)
        {
            jumpCounter--;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpPower);
        }

        if (playerRb.velocity.y < 0) //change gravity during fall for more satisfying jump
        {
            playerRb.gravityScale = fallingGravityScale;
        }
    }

    public void FixedUpdate()
    {
        if (isDashing) //disables movement during dash
        {
            return;
        }

        //Movement
        horizontalVector = new Vector2(horizontalAxis, 0);
        playerRb.velocity = new Vector2(horizontalAxis * playerSpeed, playerRb.velocity.y);
    }


    //Function for dash
    public IEnumerator Dash()
    {
        Debug.Log("coroutine dash started");
        canDash = false;
        isDashing = true;
        playerRb.gravityScale = 0;
        playerRb.velocity = new Vector2(horizontalAxis * dashSpeed,0f);
        yield return new WaitForSeconds(dashLength);
        Debug.Log("dash stopped");
        isDashing = false;

        playerRb.gravityScale = baseGravityScale;
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log("dash cooldown over");
        canDash = true;
    }



}
