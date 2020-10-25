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

    // Start is called before the first frame update
    void Start()
    {
        investigatePanelAnimator.enabled = true;
        investigatePanelAnimator.SetBool("ready", false);
    }

    void OnMouseDown()
    {
        thoughtText.text = "Perhaps we should investigate a little further...";
        optionsTrigger.gameObject.SetActive(false);
        
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
    }
}
