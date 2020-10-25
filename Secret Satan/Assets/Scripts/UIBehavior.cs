using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    public Text thoughtText;
    public GameObject optionsTrigger;

    public void ResetThoughtText()
    {
        thoughtText.text = "What gift would really give my next victim a scare...?";
    }

    public void EnableOptionsTrigger()
    {
        optionsTrigger.gameObject.SetActive(true);
    }
}
