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

    void OnMouseDown()
    {
        if (Reputation.allowSelection)
        {
            if (item.name != "Table")
            {
                thoughtText.text = "I bet the " + item.name.ToString().ToLower() + " oughta do it!";
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
