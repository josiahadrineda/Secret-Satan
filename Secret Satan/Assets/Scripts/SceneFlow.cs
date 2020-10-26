using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadScene5()
    {
        SceneManager.LoadScene("Level 5");
    }
}
