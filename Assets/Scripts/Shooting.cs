using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawner;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletTime = 5f;
    Vector2 spawnerVector;
    GameObject clone;

    void Start()
    {
        
    }

    void Update()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (Input.GetButtonDown("Fire1"))
        {
            spawnerVector = bulletSpawner.transform.position; // get the Vector of the bulletSpawner object
            ShootBullet(spawnerVector);
        }
    }

    void ShootBullet(Vector2 spawnerVector)
    {
        clone = Instantiate(bullet, spawnerVector, transform.rotation); //Create a copy of object "bullet", with Vector2 of bullet spawner and rotation of pivotPoint's rotation

        //clone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        //Destroy(clone, bulletTime);
    }
}
