using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float dashStrength = 20f;


    float horizontalAxis;
    Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        //Movement
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        horizontalAxis *= playerSpeed * Time.deltaTime;
        playerRb.velocity += new Vector2(horizontalAxis, 0f); //need to change movement, too floaty and hard to control

        //Dash
        if (Input.GetKeyUp(KeyCode.Q)) //need to add cooldown
        {
            playerRb.velocity += new Vector2(horizontalAxis * dashStrength, playerRb.velocity.y); //nic moc chtìlo by to udìlat jinak
        }
    }
}
