using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public ToggleOutlines toggleOutlines;
    public UIManager uiManager;

    public Text eventText;
    public Animator eventAnimator;
    public AudioSource eventAudioSource;

    int nextCount = 0;
    bool onlyOnce = false;

    void Start()
    {
        GlobalVars.eventInProgress = true;
        onlyOnce = true;

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            GlobalVars.tutorialThoughtException = true;
            GlobalVars.tutorialHoveredException = false;
            GlobalVars.tutorialOutlineException = true;
            GlobalVars.tutorialSideTriggerException = true;
        }
        else
        {
            GlobalVars.tutorialThoughtException = false;
            GlobalVars.tutorialHoveredException = true;
            GlobalVars.tutorialOutlineException = false;
            GlobalVars.tutorialSideTriggerException = false;
        }

        if (SceneManager.GetActiveScene().name != "Level 1" && SceneManager.GetActiveScene().name != "Level 2")
        {
            GlobalVars.eventInProgress = false;
            EnableAll();
        }
        else
        {
            DisableAll();
        }
    }

    void Update()
    {
        if (onlyOnce)
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                if (nextCount == 0)
                {
                    eventText.text = "It's the gift-giving season.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 1)
                {
                    eventText.text = "And Satan would like to win his card game against his underworld buddies.";
                }
                else if (nextCount == 2)
                {
                    eventText.text = "Click the coffee table to start playing cards.";
                }
                else if (nextCount == 3)
                {
                    SlideOut();
                    uiManager.EnableOptionsTrigger();
                    GameObject.Find("Table").GetComponent<PolygonCollider2D>().enabled = true;
                }
                else if (nextCount == 4)
                {
                    uiManager.DisableBackButton();

                    eventText.text = "Let's play a round!";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 5)
                {
                    eventText.text = "Interact with the card using left click.";
                }
                else if (nextCount == 6)
                {
                    SlideOut();

                    GlobalVars.eventInProgress = false;
                }
                else if (nextCount == 7)
                {
                    GlobalVars.eventInProgress = true;

                    eventText.text = "Read the description to decipher what this person is afraid of.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 8)
                {
                    GlobalVars.eventInProgress = false;

                    eventText.text = "Click on the X when you’re ready to choose a gift.";
                }
                else if (nextCount == 9)
                {
                    SlideOut();
                    uiManager.EnableBackButton();
                    toggleOutlines.DisableOutlines();
                }
                else if (nextCount == 10)
                {
                    GlobalVars.tutorialThoughtException = false;

                    eventText.text = "Objects that can be selected will glow. Use left click to pick one.";
                    Invoke("SlideIn", 0.5f);
                    uiManager.DisableOptionsTrigger();
                }
                else if (nextCount == 11)
                {
                    GlobalVars.tutorialOutlineException = false;

                    SlideOut();
                    EnableAll();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                if (nextCount == 0)
                {
                    eventText.text = "The options menu can be found by moving your cursor to the left edge of the screen.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 1)
                {
                    GlobalVars.eventInProgress = false;

                    GameObject.Find("Table").GetComponent<PolygonCollider2D>().enabled = true;
                    SlideOut();
                    EnableAll();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level 3")
            {
                if (nextCount == 1)
                {
                    GlobalVars.eventInProgress = true;

                    uiManager.DisableBackButton();

                    eventText.text = "The golden card belongs to your target.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 2)
                {
                    eventText.text = "Red cards belong to friends and family of the target.";
                }
                else if (nextCount == 3)
                {
                    eventText.text = "Use the extra info to figure out what your target is MOST afraid of.";
                }
                else if (nextCount == 4)
                {
                    GlobalVars.eventInProgress = false;

                    uiManager.EnableBackButton();
                    SlideOut();
                }    
            }
            else if (SceneManager.GetActiveScene().name == "Level 4")
            {
                if (nextCount == 1)
                {
                    GlobalVars.eventInProgress = true;

                    uiManager.DisableBackButton();

                    eventText.text = "Sometimes people aren’t entirely honest.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 2)
                {
                    eventText.text = "Some people lie, while others just don’t know enough.";
                }
                else if (nextCount == 3)
                {
                    eventText.text = "Find out who is telling the truth and understands our target best.";
                }
                else if (nextCount == 4)
                {
                    GlobalVars.eventInProgress = false;

                    uiManager.EnableBackButton();
                    SlideOut();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level 5")
            {
                if (nextCount == 1)
                {
                    GlobalVars.eventInProgress = true;

                    uiManager.DisableBackButton();

                    eventText.text = "Now it’s getting difficult.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 2)
                {
                    eventText.text = "See if you can eliminate any cards that contradict each other.";
                }
                else if (nextCount == 3)
                {
                    GlobalVars.eventInProgress = false;

                    uiManager.EnableBackButton();
                    SlideOut();
                }
            }

            onlyOnce = false;
        }
    }

    public void IncrementNextCount()
    {
        nextCount++;
        onlyOnce = true;
    }

    void SlideIn()
    {
        eventAnimator.SetBool("allowSlideIn", true);
        eventAnimator.SetBool("allowSlideOut", false);

        eventAudioSource.Play();
    }

    void SlideOut()
    {
        eventAnimator.SetBool("allowSlideIn", false);
        eventAnimator.SetBool("allowSlideOut", true);

        eventAudioSource.Play();
    }

    void EnableAll()
    {
        toggleOutlines.EnableOutlines();

        uiManager.DisplayThoughtPanel();
        uiManager.DisplayHoveredPanel();
        uiManager.EnableOptionsTrigger();
    }

    void DisableAll()
    {
        toggleOutlines.DisableOutlines();

        uiManager.HideThoughtPanel();
        uiManager.HideHoveredPanel();
        uiManager.DisableOptionsTrigger();
    }
}
