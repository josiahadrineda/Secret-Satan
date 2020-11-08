using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ValidateSelection : MonoBehaviour
{
    public ToggleOutlines toggleOutlines;
    public UIManager uiManager;

    public GameObject correctPanel;
    public GameObject incorrectPanel;

    public Animator correctPanelAnimator;
    public Animator incorrectPanelAnimator;

    public GameObject optionsTrigger;
    public Button optionsButton;
    public Button quitButton;

    public Text thoughtText;

    public AudioClip[] endingSfx = new AudioClip[2];
    private AudioSource backgroundAudioSource;
    private GameObject bgm;

    public VideoPlayer giftSent;
    public GameObject giftSentScreen;
    float time;
    double giftSentLength;
    bool startCheck = false;
    bool musicFade = false;
    bool onlyOnce = true;

    bool prevMusic;
    bool prevSfx;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            GlobalVars.answer = GameObject.Find("Jack in the Box");
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            GlobalVars.answer = GameObject.Find("Tombstones");
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            GlobalVars.answer = GameObject.Find("Tarantula");
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            GlobalVars.answer = GameObject.Find("Trash Bin");
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            GlobalVars.answer = GameObject.Find("Cassette Player");
        }

        time = 0;
        giftSentLength = giftSent.clip.length;

        giftSentScreen.SetActive(false);

        bgm = GameObject.Find("BGM");
        backgroundAudioSource = bgm.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (startCheck)
        {
            if (onlyOnce)
            {
                prevMusic = GlobalVars.toggleMusic;
                prevSfx = GlobalVars.toggleSfx;
                GlobalVars.toggleSfx = false;

                StartCoroutine(AudioFadeout.FadeOut(bgm, backgroundAudioSource, 0.2f));

                DisableAll();
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
                        GlobalVars.toggleSfx = true;
                    }

                    giftSentScreen.SetActive(false);
                    CheckAnswerHelper();
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
        uiManager.HideThoughtPanel();
        uiManager.HideHoveredPanel();

        if (GlobalVars.selection != GlobalVars.answer)
        {
            GlobalVars.reputation--;
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

        if (GlobalVars.toggleSfx)
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
        toggleOutlines.DisableOutlines();

        optionsTrigger.GetComponent<BoxCollider2D>().enabled = false;
        optionsButton.interactable = false;
        quitButton.interactable = false;
    }

    void EnableAll()
    {
        toggleOutlines.EnableOutlines();

        optionsTrigger.GetComponent<BoxCollider2D>().enabled = true;
        optionsButton.interactable = true;
        quitButton.interactable = true;
    }
}
