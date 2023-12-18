using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Transform bulletSpawner;
    Vector2 cursorPosition;
    float angleToCursor;
    Quaternion spawnerRotation;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawner = gameObject.transform;
        spawnerRotation = bulletSpawner.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Camera.main.WorldToScreenPoint(Input.mousePosition); //get position of cursor in world camera
        angleToCursor = Mathf.Atan2(cursorPosition.y, cursorPosition.x) * Mathf.Rad2Deg; //calculate angle to cursor to rotate bulletSpawner


        bulletSpawner.transform.rotation = spawnerRotation * Quaternion.Euler(0, 0, angleToCursor); //rotation of bulletspawner around player to the cursor
    }

    void Shooting()
    {

    }
}
