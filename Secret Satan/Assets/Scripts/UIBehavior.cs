using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    public Text thoughtText;
    public GameObject optionsTrigger;
    public GameObject optionsPanel;
    public GameObject quitPanel;
    public Button optionsButton;
    public Button quitButton;

    public void ResetThoughtText()
    {
        thoughtText.text = "What gift would really give my next victim a scare...?";
    }

    public void EnableOptionsTrigger()
    {
        optionsTrigger.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DisableOptionsTrigger()
    {
        optionsTrigger.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DisplayOptionsPanel()
    {
        optionsPanel.gameObject.SetActive(true);
    }

    public void HideOptionsPanel()
    {
        optionsPanel.gameObject.SetActive(false);
    }

    public void DisplayQuitPanel()
    {
        quitPanel.gameObject.SetActive(true);
    }

    public void HideQuitPanel()
    {
        quitPanel.gameObject.SetActive(false);
    }

    public void EnableOptionsButton()
    {
        optionsButton.interactable = true;
    }

    public void DisableOptionsButton()
    {
        optionsButton.interactable = false;
    }

    public void EnableQuitButton()
    {
        quitButton.interactable = true;
    }

    public void DisableQuitButton()
    {
        quitButton.interactable = false;
    }
}
