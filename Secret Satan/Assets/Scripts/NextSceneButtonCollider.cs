using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneButtonCollider : MonoBehaviour
{
    public SceneFlow sceneFlow;
    public Sprite buttonDown;
    public Sprite buttonUp;

    void OnMouseDown()
    {
        GetComponent<Image>().sprite = buttonDown;
    }

    void OnMouseUp()
    {
        GetComponent<Image>().sprite = buttonUp;
        
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            sceneFlow.LoadScene2();
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            sceneFlow.LoadScene3();
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            sceneFlow.LoadScene4();
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            sceneFlow.LoadScene5();
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            sceneFlow.GoToDemoEnd();
        }
        else if (SceneManager.GetActiveScene().name == "DemoEnd")
        {
            sceneFlow.ReturnToMenu();
        }
    }
}
