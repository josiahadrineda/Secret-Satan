using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHoverText : MonoBehaviour
{
    public Text hoveredText;

    void OnMouseOver()
    {
        if (gameObject.name != "Table")
        {
            hoveredText.text = gameObject.name.ToString();
        }
    }

    void OnMouseExit()
    {
        if (Reputation.selectedTableOnce)
        {
            hoveredText.text = "Pick a gift.";
        }
        else
        {
            hoveredText.text = "Select the table.";
        }
    }
}
