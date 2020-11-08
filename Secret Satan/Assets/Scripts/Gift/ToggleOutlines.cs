using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOutlines : MonoBehaviour
{
    public GameObject[] layers = new GameObject[5];

    public void EnableOutlines()
    {
        if (!GlobalVars.eventInProgress && !GlobalVars.tutorialOutlineException)
        {
            foreach (GameObject layer in layers)
            {
                foreach (Transform item in layer.transform)
                {
                    GameObject childItem = item.gameObject;
                    if (childItem.GetComponent<PolygonCollider2D>() != null)
                    {
                        childItem.GetComponent<PolygonCollider2D>().enabled = true;
                    }
                }
            }
        }
    }

    public void DisableOutlines()
    {
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
    }
}
