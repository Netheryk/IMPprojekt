using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Transform bulletSpawner;
    Vector3 cursorPosition;
    float angleToCursor;
    Quaternion spawnerRotation;
    Vector3 rotation;
    float rotZ;

    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(Input.mousePosition); //get position of cursor in world camera
                                                                                                                                        //angleToCursor = Mathf.Atan2(cursorPosition.y, cursorPosition.x) * Mathf.Rad2Deg; //calculate angle to cursor to rotate bulletSpawner
        transform.rotation = Quaternion.LookRotation(Vector3.forward, cursorPosition - transform.position);

        /*
        rotation = cursorPosition - transform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        */
        //transform.rotation = transform.rotation * Quaternion.Euler(0, 0, rotZ); //rotation of bulletspawner around player to the cursor
        if(Input.GetButtonUp("Fire1"))
        {
        }
    }


}
