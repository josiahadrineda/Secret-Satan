using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Security.Cryptography;

public class Transitions : MonoBehaviour
{
    public float speed = 1f;

    public Image transitionImage;

    // Start is called before the first frame update
    void Start()
    {
        Reputation.fade = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Reputation.fade)
        {
            // Fade in
            Color transitionColor = transitionImage.color;
            transitionColor.a = Mathf.MoveTowards(transitionColor.a, 0f, speed * Time.deltaTime);
            transitionImage.color = transitionColor;
        }
        else
        {
            // Fade out
            Color transitionColor = transitionImage.color;
            transitionColor.a = Mathf.MoveTowards(transitionColor.a, 1f, speed * Time.deltaTime);
            transitionImage.color = transitionColor;
        }
    }
}
