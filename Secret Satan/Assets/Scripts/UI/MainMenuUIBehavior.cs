using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainMenuUIBehavior : MonoBehaviour
{
    private GameManager gameManager;

    public Button playButton;
    public Button optionsButton;
    public Button quitButton;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playButton.onClick.AddListener(gameManager.LoadScene1);
        quitButton.onClick.AddListener(gameManager.QuitGame);
    }

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
