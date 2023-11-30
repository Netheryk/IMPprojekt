using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Light : MonoBehaviour
{
    private string sceneName;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(sceneName); //for now collision reloads current scene, should instead damage/kill player
            Debug.Log("player touched light");
        }
    }
}
