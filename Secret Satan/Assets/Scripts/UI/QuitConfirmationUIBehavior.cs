using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class QuitConfirmationUIBehavior : MonoBehaviour
{
    private GameManager gameManager;

    public Button yesButton;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        yesButton.onClick.AddListener(gameManager.ReturnToMenu);
    }
}
