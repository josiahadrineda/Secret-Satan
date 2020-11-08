using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneButtonCollider : MonoBehaviour
{
    private GameManager gameManager;

    public Sprite buttonDown;
    public Sprite buttonUp;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnMouseDown()
    {
        GetComponent<Image>().sprite = buttonDown;
    }

    void OnMouseUp()
    {
        GetComponent<Image>().sprite = buttonUp;
        
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            gameManager.LoadScene2();
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            gameManager.LoadScene3();
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            gameManager.LoadScene4();
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            gameManager.LoadScene5();
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            gameManager.GoToDemoEnd();
        }
        else if (SceneManager.GetActiveScene().name == "DemoEnd")
        {
            gameManager.ReturnToMenu();
        }
    }
}
