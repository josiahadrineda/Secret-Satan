using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    public GameObject item;

    public Text thoughtText;

    public Button yesButton;
    public Button noButton;

    public GameObject[] layers = new GameObject[5];

    // Use this for initialization
    void Start()
    {
        Reputation.allowSelection = false;
    }

    void OnMouseDown()
    {
        if (Reputation.allowSelection)
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

                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);

                foreach (GameObject layer in layers)
                {
                    foreach (Transform item in layer.transform)
                    {
                        GameObject childItem = item.gameObject;
                        if (childItem.GetComponent<PolygonCollider2D>() != null)
                        {
                            childItem.GetComponent<PolygonCollider2D>().enabled = false;
                        }
                    }
                }

                Reputation.selection = item;
            }
        }
    }
}
