using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadFloor1 : MonoBehaviour
{
    //[SerializeField] private AudioSource finishSound;

    // private bool levelCompleted = false;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //finishSound.Play();
            // levelCompleted = true;
            Dead1();
        }
    }

    private void Dead1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}