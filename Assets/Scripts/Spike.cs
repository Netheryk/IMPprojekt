using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private string sceneName;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("player stepped on spike");
        }
    }
}
