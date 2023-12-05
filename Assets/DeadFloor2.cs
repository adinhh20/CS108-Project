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

            PlayerDied();
        }
    }

    public void PlayerDied()
    {
        // Store the name of the current scene in PlayerPrefs
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        // Load the restart scene
        SceneManager.LoadScene("RestartScene"); // Assuming restart scene is at index 3
    }
}