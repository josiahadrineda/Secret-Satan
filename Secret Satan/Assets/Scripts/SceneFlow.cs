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

    public void GameOver()
    {
        Reputation.fade = false;
        Invoke("SwapEnd", 1f);
    }

    public void ReturnToMenu()
    {
        Reputation.reputation = 3;
        Reputation.fade = false;
        Invoke("SwapMenu", 1f);
    }

    public void GoToDemoEnd()
    {
        Reputation.fade = false;
        Invoke("SwapDemo", 1f);
    }

    public void LoadScene1()
    {
        Reputation.fade = false;
        Invoke("Swap1", 1f);
    }

    public void LoadScene2()
    {
        Reputation.fade = false;
        Invoke("Swap2", 1f);
    }

    public void LoadScene3()
    {
        Reputation.fade = false;
        Invoke("Swap3", 1f);
    }

    public void LoadScene4()
    {
        Reputation.fade = false;
        Invoke("Swap4", 1f);
    }

    public void LoadScene5()
    {
        Reputation.fade = false;
        Invoke("Swap5", 1f);
    }

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
