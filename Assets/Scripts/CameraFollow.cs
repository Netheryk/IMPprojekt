using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector3 playerPosition;

    // Update is called once per frame
    void Update()
    {
        // update camera position to player's position every frame
        playerPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, -10f); //-10f is default camera Z position
        transform.position = playerPosition;
    }
}
