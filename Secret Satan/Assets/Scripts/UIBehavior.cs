using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    public Text thoughtText;
    public Text hoveredText;
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

    public Toggle musicToggle;
    public GameObject musicBackground;
    public Toggle sfxToggle;
    public GameObject sfxBackground;
    public Sprite checkedImage;
    public Sprite uncheckedImage;

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
        if (!Reputation.tutorialSideTriggerException)
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
        if (Reputation.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void HideOptionsPanel()
    {
        optionsPanel.gameObject.SetActive(false);

        GetComponent<AudioSource>().clip = pageTurnSfx;
        if (Reputation.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void DisplayQuitPanel()
    {
        quitPanel.gameObject.SetActive(true);

        GetComponent<AudioSource>().clip = pageTurnSfx;
        if (Reputation.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void HideQuitPanel()
    {
        quitPanel.gameObject.SetActive(false);

        GetComponent<AudioSource>().clip = pageTurnSfx;
        if (Reputation.toggleSfx)
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
        thoughtPanel.gameObject.SetActive(true);
    }

    public void HideThoughtPanel()
    {
        thoughtPanel.gameObject.SetActive(false);
    }

    public void DisplayHoveredPanel()
    {
        if (Reputation.tutorialHoveredException)
        {
            hoveredPanel.gameObject.SetActive(true);
        }

        Reputation.tutorialHoveredException = true;
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

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            musicBackground.GetComponent<Image>().sprite = checkedImage;
            GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM>().PlayMusic();
        }
        else
        {
            musicBackground.GetComponent<Image>().sprite = uncheckedImage;
            GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM>().PauseMusic();
        }

        Reputation.toggleMusic = !Reputation.toggleMusic;
    }

    public void ToggleSfx()
    {
        if (sfxToggle.isOn)
        {
            sfxBackground.GetComponent<Image>().sprite = checkedImage;
        }
        else
        {
            sfxBackground.GetComponent<Image>().sprite = uncheckedImage;
        }

        Reputation.toggleSfx = !Reputation.toggleSfx;
    }
}
