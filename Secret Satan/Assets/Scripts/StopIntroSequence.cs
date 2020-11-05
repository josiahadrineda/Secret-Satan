using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StopIntroSequence : MonoBehaviour
{
    public float time = 0f;
    public double introLength;
    public float speed = 1f;

    public VideoPlayer introPlayer;
    public RawImage introScreen;
    public AudioSource introSequence;

    bool onlyOnce = true;
    bool beginFade = false;
    bool transitionOnce = true;

    public SceneFlow sceneFlow;

    // Start is called before the first frame update
    void Start()
    {
        introLength = introPlayer.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if ((time >= 7.5f && Input.anyKey) || time >= introLength)
        {
            if (onlyOnce)
            {
                beginFade = true;
                onlyOnce = false;
            }
        }

        if (beginFade && (introScreen.color.r != 0f || introScreen.color.g != 0f || introScreen.color.b != 0f || introSequence.volume != 0f))
        {
            Color introScreenColor = introScreen.color;
            introScreenColor.r = Mathf.MoveTowards(introScreenColor.r, 0f, speed * 1.6f * Time.deltaTime);
            introScreenColor.g = Mathf.MoveTowards(introScreenColor.g, 0f, speed * 1.6f * Time.deltaTime);
            introScreenColor.b = Mathf.MoveTowards(introScreenColor.b, 0f, speed * 1.6f * Time.deltaTime);
            introScreen.color = introScreenColor;

            introSequence.volume = Mathf.MoveTowards(introSequence.volume, 0f, speed * 0.4f * Time.deltaTime);
        }
        else if (introScreen.color.r == 0f && introScreen.color.g == 0f && introScreen.color.b == 0f && introSequence.volume == 0f)
        {
            if (transitionOnce)
            {
                sceneFlow.Invoke("ReturnToMenu", 0f);
                transitionOnce = false;
            }
        }
    }
}
