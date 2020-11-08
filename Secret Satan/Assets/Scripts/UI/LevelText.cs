using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    public Text levelText;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            levelText.text = "1";
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            levelText.text = "2";
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            levelText.text = "3";
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            levelText.text = "4";
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            levelText.text = "5";
        }
    }
}
