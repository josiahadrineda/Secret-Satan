using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCards : MonoBehaviour
{
    public Text thoughtText;
    public GameObject optionsTrigger;

    public GameObject[] layers = new GameObject[5];

    public Animator investigatePanelAnimator;

    public UIBehavior uiBehavior;
    public Events events;

    bool onlyOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        investigatePanelAnimator.enabled = true;
        investigatePanelAnimator.SetBool("ready", false);
    }

    void OnMouseDown()
    {
        thoughtText.text = "Perhaps we should investigate a little further...";
        optionsTrigger.GetComponent<BoxCollider2D>().enabled = false;

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

        investigatePanelAnimator.SetBool("ready", true);
        investigatePanelAnimator.SetBool("reverseReady", false);

        Reputation.allowSelection = true;
        Reputation.selectedTableOnce = true;

        uiBehavior.Invoke("HideHoveredPanel", 0f);
        
        if (onlyOnce)
        {
            events.Invoke("IncrementNextCount", 0f);
            onlyOnce = false;
        }
    }
}
