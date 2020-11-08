using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionsTrigger;
    public GameObject optionsPanel;
    public GameObject quitPanel;
    public GameObject incorrectPanel;
    public GameObject thoughtPanel;
    public GameObject hoveredPanel;
    public Button optionsButton;

    public Button quitButton;
    public Button backButton;
    public Button yesButton;
    public Button noButton;

    public Text thoughtText;
    public Text hoveredText;

    public AudioClip pageTurnSfx;

    public void ResetThoughtText()
    {
        thoughtText.text = "What gift would really give my next victim a scare...?";
    }

    public void ResetHoveredText()
    {
        hoveredText.text = "Pick a gift.";
    }

    public void EnableOptionsTrigger()
    {
        if (!GlobalVars.tutorialSideTriggerException)
        {
            optionsTrigger.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void DisableOptionsTrigger()
    {
        optionsTrigger.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DisplayOptionsPanel()
    {
        optionsPanel.gameObject.SetActive(true);

        GetComponent<AudioSource>().clip = pageTurnSfx;
        if (GlobalVars.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void HideOptionsPanel()
    {
        optionsPanel.gameObject.SetActive(false);

        GetComponent<AudioSource>().clip = pageTurnSfx;
        if (GlobalVars.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void DisplayQuitPanel()
    {
        quitPanel.gameObject.SetActive(true);

        GetComponent<AudioSource>().clip = pageTurnSfx;
        if (GlobalVars.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void HideQuitPanel()
    {
        quitPanel.gameObject.SetActive(false);

        GetComponent<AudioSource>().clip = pageTurnSfx;
        if (GlobalVars.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void HideIncorrectPanel()
    {
        incorrectPanel.gameObject.SetActive(false);
    }

    public void DisplayThoughtPanel()
    {
        if (GlobalVars.selectedTableOnce && !GlobalVars.tutorialThoughtException)
        {
            thoughtPanel.gameObject.SetActive(true);
        }
    }

    public void HideThoughtPanel()
    {
        thoughtPanel.gameObject.SetActive(false);
    }

    public void DisplayHoveredPanel()
    {
        if (GlobalVars.tutorialHoveredException)
        {
            hoveredPanel.gameObject.SetActive(true);
        }

        GlobalVars.tutorialHoveredException = true;
    }

    public void HideHoveredPanel()
    {
        hoveredPanel.gameObject.SetActive(false);
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

    public void EnableBackButton()
    {
        backButton.interactable = true;
    }

    public void DisableBackButton()
    {
        backButton.interactable = false;
    }

    public void EnableYesButton()
    {
        yesButton.interactable = true;
    }

    public void DisableYesButton()
    {
        yesButton.interactable = false;
    }

    public void EnableNoButton()
    {
        noButton.interactable = true;
    }

    public void DisableNoButton()
    {
        noButton.interactable = false;
    }
}
