using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHand : MonoBehaviour
{
    public int numCards = 3;
    public Canvas canvas;
    public GameObject cardPrefab;

    public Button backButton;

    public GameObject[] layers = new GameObject[5];

    public Animator investigatePanelAnimator;

    public void GenerateHand()
    {
        RectTransform canvasTransform = canvas.GetComponent<RectTransform>();
        float canvasWidth = canvasTransform.rect.width;
        float step = canvasWidth / numCards;
        float[] xPos = new float[numCards];

        float currX = (-canvasWidth / 2) + (step / 2);
        for (int i = 0; i < numCards; i++)
        {
            xPos[i] = currX;
            currX += step;
        }

        foreach (float x in xPos)
        {
            GameObject card = GameObject.Instantiate(cardPrefab);
            RectTransform cardTransform = card.GetComponent<RectTransform>();
            cardTransform.SetParent(canvasTransform, false);
            cardTransform.offsetMin += new Vector2(x, 0);
            cardTransform.offsetMax -= new Vector2(x * -1, 0);
        }

        backButton.gameObject.SetActive(true);
    }

    public void WithdrawHand()
    {
        foreach (RectTransform card in canvas.transform)
        {
            GameObject childItem = card.gameObject;
            if (childItem.GetComponent<CardDisplay>() != null)
            {
                Destroy(childItem);
            }
        }

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

        investigatePanelAnimator.SetBool("reverseReady", true);
        investigatePanelAnimator.SetBool("ready", false);

        backButton.gameObject.SetActive(false);
    }

    // Future Update: Parallax on mouse hover
    void Update()
    {

    }
}
