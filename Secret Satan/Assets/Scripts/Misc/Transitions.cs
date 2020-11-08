using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public float speed = 1f;

    public Image transitionImage;

    void Start()
    {
        GlobalVars.fade = true;
    }

    void Update()
    {
        if (GlobalVars.fade)
        {
            Color transitionColor = transitionImage.color;
            transitionColor.a = Mathf.MoveTowards(transitionColor.a, 0f, speed * Time.deltaTime);
            transitionImage.color = transitionColor;
        }
        else
        {
            Color transitionColor = transitionImage.color;
            transitionColor.a = Mathf.MoveTowards(transitionColor.a, 1f, speed * Time.deltaTime);
            transitionImage.color = transitionColor;
        }
    }
}
