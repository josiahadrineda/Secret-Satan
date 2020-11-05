using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIBehavior : MonoBehaviour
{
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;

    public void EnableAll()
    {
        playButton.interactable = true;
        optionsButton.interactable = true;
        quitButton.interactable = true;
    }

    public void DisableAll()
    {
        playButton.interactable = false;
        optionsButton.interactable = false;
        quitButton.interactable = false;
    }
}
