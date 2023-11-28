using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadFloor2 : MonoBehaviour
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
            Dead();
        }
    }

    private void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}