using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        GlobalVars.fade = false;
        instance.Invoke("SwapEnd", 1f);
    }

    public void ReturnToMenu()
    {
        GlobalVars.reputation = 3;
        GlobalVars.fade = false;
        instance.Invoke("SwapMenu", 1f);
    }

    public void GoToDemoEnd()
    {
        GlobalVars.fade = false;
        instance.Invoke("SwapDemo", 1f);
    }

    public void LoadScene1()
    {
        GlobalVars.fade = false;
        instance.Invoke("Swap1", 1f);
    }

    public void LoadScene2()
    {
        GlobalVars.fade = false;
        instance.Invoke("Swap2", 1f);
    }

    public void LoadScene3()
    {
        GlobalVars.fade = false;
        instance.Invoke("Swap3", 1f);
    }

    public void LoadScene4()
    {
        GlobalVars.fade = false;
        instance.Invoke("Swap4", 1f);
    }

    public void LoadScene5()
    {
        GlobalVars.fade = false;
        instance.Invoke("Swap5", 1f);
    }

    // -----------------------------------------

    void SwapMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void SwapDemo()
    {
        SceneManager.LoadScene("DemoEnd");
    }

    void SwapEnd()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Swap1()
    {
        SceneManager.LoadScene("Level 1");
    }

    void Swap2()
    {
        SceneManager.LoadScene("Level 2");
    }

    void Swap3()
    {
        SceneManager.LoadScene("Level 3");
    }

    void Swap4()
    {
        SceneManager.LoadScene("Level 4");
    }

    void Swap5()
    {
        SceneManager.LoadScene("Level 5");
    }
}
