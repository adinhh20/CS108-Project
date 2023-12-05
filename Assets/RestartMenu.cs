using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{


    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        // Retrieve the stored level name from PlayerPrefs
        string currentLevel = PlayerPrefs.GetString("CurrentLevel"); // Adjust the default value as needed

        // Load the corresponding level
        SceneManager.LoadScene(currentLevel);
    }
}