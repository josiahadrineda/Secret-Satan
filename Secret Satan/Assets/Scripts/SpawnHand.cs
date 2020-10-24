using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SpawnHand : MonoBehaviour
{
    public int numCards = 3;
    public Canvas canvas;
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform canvasTransform = canvas.GetComponent<RectTransform>();
        float canvasWidth = canvasTransform.rect.width;
        float step = canvasWidth / (numCards + 1);
        float[] xPos = new float[numCards];

        float currX = (-canvasWidth / 2) + step;
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
    }
}
