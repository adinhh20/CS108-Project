using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnimator;

    public void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        transitionAnimator.SetTrigger("Start"); // Trigger the fade-out animation

        yield return new WaitForSeconds(1); // Adjust this time to match the duration of your fade-out animation

        SceneManager.LoadScene(sceneName); // Load the new scene

        // Optionally, you can fade in after loading the scene by triggering a fade-in animation
        // transitionAnimator.SetTrigger("End");
    }
}
