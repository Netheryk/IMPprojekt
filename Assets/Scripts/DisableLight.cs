using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLight : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, gameManager);
        }
    }
}
