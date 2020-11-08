using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    public ToggleOutlines toggleOutlines;
    public GameObject item;

    public Text thoughtText;
    public GameObject hoveredPanel;

    public Button yesButton;
    public Button noButton;

    public GameObject[] layers = new GameObject[5];

    void Start()
    {
        GlobalVars.allowSelection = false;
    }

    void OnMouseDown()
    {
        if (GlobalVars.allowSelection)
        {
            if (item.name != "Table")
            {
                if (item.name != "Pithius the Python" && item.name != "Cerberus Jr.")
                {
                    thoughtText.text = "I bet my " + item.name.ToString().ToLower() + " oughta do it!";
                }
                else
                {
                    thoughtText.text = "I bet " + item.name.ToString() + " oughta do it!";
                }

                hoveredPanel.SetActive(false);

                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);

                toggleOutlines.DisableOutlines();

                GlobalVars.selection = item;
            }
        }
    }
}
