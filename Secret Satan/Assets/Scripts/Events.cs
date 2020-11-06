using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public UIBehavior uiBehavior;
    public ToggleOutlines toggleOutlines;

    public Text eventText;
    public Animator eventAnimator;
    public AudioSource eventAudioSource;

    int nextCount = 0;
    bool onlyOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        Reputation.eventInProgress = true;
        onlyOnce = true;

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Reputation.tutorialThoughtException = true;
            Reputation.tutorialHoveredException = false;
            Reputation.tutorialOutlineException = true;
            Reputation.tutorialSideTriggerException = true;
        }
        else
        {
            Reputation.tutorialThoughtException = false;
            Reputation.tutorialHoveredException = true;
            Reputation.tutorialOutlineException = false;
            Reputation.tutorialSideTriggerException = false;
        }

        if (SceneManager.GetActiveScene().name != "Level 1" && SceneManager.GetActiveScene().name != "Level 2")
        {
            Invoke("EnableAll", 0f);
        }
        else
        {
            Invoke("DisableAll", 0f);
        }
    }

    // Update is called once per frame
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
                    Invoke("SlideOut", 0f);
                    uiBehavior.Invoke("EnableOptionsTrigger", 0f);
                    GameObject.Find("Table").GetComponent<PolygonCollider2D>().enabled = true;
                }
                else if (nextCount == 4)
                {
                    uiBehavior.Invoke("DisableBackButton", 0f);

                    eventText.text = "Let's play a round!";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 5)
                {
                    eventText.text = "Interact with the card using left click.";
                }
                else if (nextCount == 6)
                {
                    Invoke("SlideOut", 0f);

                    Reputation.eventInProgress = false;
                }
                else if (nextCount == 7)
                {
                    Reputation.eventInProgress = true;

                    eventText.text = "Read the description to decipher what this person is afraid of.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 8)
                {
                    Reputation.eventInProgress = false;

                    eventText.text = "Click on the X when you’re ready to choose a gift.";
                }
                else if (nextCount == 9)
                {
                    Invoke("SlideOut", 0f);
                    uiBehavior.Invoke("EnableBackButton", 0f);
                    toggleOutlines.Invoke("DisableOutlines", 0f);
                }
                else if (nextCount == 10)
                {
                    Reputation.tutorialThoughtException = false;
                    eventText.text = "Objects that can be selected will glow. Use left click to pick one.";
                    Invoke("SlideIn", 0.5f);
                    uiBehavior.Invoke("DisableOptionsTrigger", 0f);
                }
                else if (nextCount == 11)
                {
                    Reputation.tutorialOutlineException = false;

                    Invoke("SlideOut", 0f);
                    Invoke("EnableAll", 0f);
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
                    Reputation.eventInProgress = false;

                    GameObject.Find("Table").GetComponent<PolygonCollider2D>().enabled = true;
                    Invoke("SlideOut", 0f);
                    Invoke("EnableAll", 0f);
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level 3")
            {
                if (nextCount == 0)
                {
                    Reputation.eventInProgress = false;
                }
                if (nextCount == 1)
                {
                    Reputation.eventInProgress = true;
                    uiBehavior.Invoke("DisableBackButton", 0f);

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
                    Reputation.eventInProgress = false;

                    uiBehavior.Invoke("EnableBackButton", 0f);
                    Invoke("SlideOut", 0f);
                }    
            }
            else if (SceneManager.GetActiveScene().name == "Level 4")
            {
                if (nextCount == 0)
                {
                    Reputation.eventInProgress = false;
                }
                if (nextCount == 1)
                {
                    Reputation.eventInProgress = true;
                    uiBehavior.Invoke("DisableBackButton", 0f);

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
                    Reputation.eventInProgress = false;

                    uiBehavior.Invoke("EnableBackButton", 0f);
                    Invoke("SlideOut", 0f);
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level 5")
            {
                if (nextCount == 0)
                {
                    Reputation.eventInProgress = false;
                }
                if (nextCount == 1)
                {
                    Reputation.eventInProgress = true;
                    uiBehavior.Invoke("DisableBackButton", 0f);

                    eventText.text = "Now it’s getting difficult.";
                    Invoke("SlideIn", 1f);
                }
                else if (nextCount == 2)
                {
                    eventText.text = "See if you can eliminate any cards that contradict each other.";
                }
                else if (nextCount == 3)
                {
                    Reputation.eventInProgress = false;

                    uiBehavior.Invoke("EnableBackButton", 0f);
                    Invoke("SlideOut", 0f);
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
        uiBehavior.Invoke("DisplayThoughtPanel", 0f);
        uiBehavior.Invoke("DisplayHoveredPanel", 0f);
        uiBehavior.Invoke("EnableOptionsTrigger", 0f);
        toggleOutlines.Invoke("EnableOutlines", 0f);
    }

    void DisableAll()
    {
        uiBehavior.Invoke("HideThoughtPanel", 0f);
        uiBehavior.Invoke("HideHoveredPanel", 0f);
        uiBehavior.Invoke("DisableOptionsTrigger", 0f);
        toggleOutlines.Invoke("DisableOutlines", 0f);
    }
}
