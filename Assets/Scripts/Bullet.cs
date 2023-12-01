using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    Light2D collidedLight;
    Rigidbody2D bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletRb.velocity = new Vector2(bulletSpeed,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("LightHitbox")) //detecting if bullet hit a light and "disabling" it
        {
            collidedLight = collision.GetComponent<Light2D>();
            collidedLight.intensity = 0.2f;
        }
        collision.CompareTag("LightHitbox");
    }
}
