using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ChangeHoverText : MonoBehaviour
{
    public Text hoveredText;

    void Start()
    {
        GlobalVars.selectedTableOnce = false;
    }

    void OnMouseOver()
    {
        if (gameObject.name != "Table")
        {
            hoveredText.text = gameObject.name.ToString();
        }
    }

    void OnMouseExit()
    {
        if (GlobalVars.selectedTableOnce)
        {
            hoveredText.text = "Pick a gift.";
        }
        else
        {
            hoveredText.text = "Select the table.";
        }
    }
}
