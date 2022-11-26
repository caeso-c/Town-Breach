using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f; // set time back to 1 for normal function
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
