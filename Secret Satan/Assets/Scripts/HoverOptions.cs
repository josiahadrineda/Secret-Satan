using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverOptions : MonoBehaviour
{
    public Button optionsButton;
    public Button quitButton;
    public Animator optionsButtonAnimator;
    public Animator quitButtonAnimator;

    // Use this for initialization
    public void Start()
    {
        optionsButtonAnimator.enabled = true;
        quitButtonAnimator.enabled = true;
        optionsButtonAnimator.SetBool("ready", false);
        quitButtonAnimator.SetBool("ready", false);
    }

    public void OnMouseOver()
    {
        optionsButtonAnimator.SetBool("ready", true);
        quitButtonAnimator.SetBool("ready", true);
    }

    public void OnMouseExit()
    {
        optionsButtonAnimator.SetBool("ready", false);
        quitButtonAnimator.SetBool("ready", false);
    }
}
