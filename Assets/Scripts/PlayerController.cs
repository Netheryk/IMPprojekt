using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float dashSpeed = 20f;

    Vector2 horizontalVector;
    float horizontalAxis;
    Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        //Dash

    }

    private void FixedUpdate()
    {
        //Movement
        horizontalVector = new Vector2(horizontalAxis, 0);
        playerRb.velocity = new Vector2(horizontalAxis * playerSpeed, playerRb.velocity.y);

        if (Input.GetKeyUp(KeyCode.Q)) //need to add cooldown
        {
            playerRb.velocity += new Vector2(horizontalAxis * dashSpeed, playerRb.velocity.y);
        }
    }



}
