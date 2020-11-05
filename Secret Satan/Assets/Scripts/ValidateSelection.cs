using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System;

public class ValidateSelection : MonoBehaviour
{
    public ToggleOutlines toggleOutlines;
    public UIBehavior uiBehavior;

    public GameObject correctPanel;
    public GameObject incorrectPanel;

    public Animator correctPanelAnimator;
    public Animator incorrectPanelAnimator;

    public GameObject optionsTrigger;
    public Button optionsButton;
    public Button quitButton;

    public Text thoughtText;

    public AudioClip[] endingSfx = new AudioClip[2];
    public AudioSource backgroundAudioSource;
    public GameObject bgm;

    public VideoPlayer giftSent;
    public GameObject giftSentScreen;
    float time;
    double giftSentLength;
    bool startCheck = false;
    bool musicFade = false;
    bool onlyOnce = true;

    bool prevMusic;
    bool prevSfx;

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Reputation.answer = GameObject.Find("Jack in the Box");
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Reputation.answer = GameObject.Find("Tombstones");
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Reputation.answer = GameObject.Find("Tarantula");
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            Reputation.answer = GameObject.Find("Trash Bin");
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            Reputation.answer = GameObject.Find("Cassette Player");
        }

        time = 0;
        giftSentLength = giftSent.clip.length;

        giftSentScreen.SetActive(false);

        backgroundAudioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCheck)
        {
            if (onlyOnce)
            {
                prevMusic = Reputation.toggleMusic;
                prevSfx = Reputation.toggleSfx;
                Reputation.toggleSfx = false;

                StartCoroutine(AudioFadeout.FadeOut(bgm, backgroundAudioSource, 0.2f));

                Invoke("DisableAll", 0f);
                Invoke("BeginGiftSent", 1.5f);
                
                onlyOnce = false;
            }

            if (musicFade)
            {
                time += Time.deltaTime;
                if (time >= giftSentLength)
                {
                    if (prevMusic)
                    {
                        StartCoroutine(AudioFadeout.FadeIn(bgm, backgroundAudioSource, 0.2f));
                    }
                    if (prevSfx)
                    {
                        Reputation.toggleSfx = true;
                    }

                    giftSentScreen.SetActive(false);
                    Invoke("CheckAnswerHelper", 0f);
                }
            }
        }
    }

    public void CheckAnswer()
    {
        startCheck = true;
    }

    void BeginGiftSent()
    {
        musicFade = true;

        giftSentScreen.SetActive(true);
        giftSent.Play();
    }

    void CheckAnswerHelper()
    {
        uiBehavior.Invoke("HideThoughtPanel", 0f);
        uiBehavior.Invoke("HideHoveredPanel", 0f);

        if (Reputation.selection != Reputation.answer)
        {
            Reputation.reputation--;
            incorrectPanel.gameObject.SetActive(true);
            incorrectPanelAnimator.SetBool("ready", true);
            GetComponent<AudioSource>().clip = endingSfx[1];
        }
        else
        {
            correctPanel.gameObject.SetActive(true);
            correctPanelAnimator.SetBool("ready", true);
            GetComponent<AudioSource>().clip = endingSfx[0];
        }

        if (Reputation.toggleSfx)
        {
            GetComponent<AudioSource>().Play();
        }

        startCheck = false;
        musicFade = false;
        onlyOnce = true;
        time = 0;
    }

    void DisableAll()
    {
        toggleOutlines.Invoke("DisableOutlines", 0f);

        optionsTrigger.GetComponent<BoxCollider2D>().enabled = false;
        optionsButton.interactable = false;
        quitButton.interactable = false;
    }

    void EnableAll()
    {
        toggleOutlines.Invoke("EnableOutlines", 0f);

        optionsTrigger.GetComponent<BoxCollider2D>().enabled = true;
        optionsButton.interactable = true;
        quitButton.interactable = true;
    }
}
