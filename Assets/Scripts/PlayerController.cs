using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    private float horizontalAxis;
    private float playerSpeed = 8f;






    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");

        horizontalAxis *= playerSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontalAxis, 0f, 0f));
    }
}
