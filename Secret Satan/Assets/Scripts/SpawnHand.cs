using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Versioning;

public class SpawnHand : MonoBehaviour
{
    public int numCards;
    public GameObject[] cardPrefabs;

    public Canvas canvas;

    public Button backButton;
    public Text thoughtText;

    public Animator investigatePanelAnimator;

    // Use this for initialization
    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            numCards = 1;
            cardPrefabs = new GameObject[numCards];
            cardPrefabs[0] = Resources.Load<GameObject>("Prefabs/Level 1/1_1");
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            numCards = 1;
            cardPrefabs = new GameObject[numCards];
            cardPrefabs[0] = Resources.Load<GameObject>("Prefabs/Level 2/2_1");
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            numCards = 2;
            cardPrefabs = new GameObject[numCards];
            cardPrefabs[0] = Resources.Load<GameObject>("Prefabs/Level 3/3_1");
            cardPrefabs[1] = Resources.Load<GameObject>("Prefabs/Level 3/3_2");
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            numCards = 3;
            cardPrefabs = new GameObject[numCards];
            cardPrefabs[0] = Resources.Load<GameObject>("Prefabs/Level 4/4_1");
            cardPrefabs[1] = Resources.Load<GameObject>("Prefabs/Level 4/4_2");
            cardPrefabs[2] = Resources.Load<GameObject>("Prefabs/Level 4/4_3");
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            numCards = 5;
            cardPrefabs = new GameObject[numCards];
            cardPrefabs[0] = Resources.Load<GameObject>("Prefabs/Level 5/5_1");
            cardPrefabs[1] = Resources.Load<GameObject>("Prefabs/Level 5/5_2");
            cardPrefabs[2] = Resources.Load<GameObject>("Prefabs/Level 5/5_3");
            cardPrefabs[3] = Resources.Load<GameObject>("Prefabs/Level 5/5_4");
            cardPrefabs[4] = Resources.Load<GameObject>("Prefabs/Level 5/5_5");
        }
    }

    public void GenerateHand()
    {
        RectTransform canvasTransform = canvas.GetComponent<RectTransform>();
        float canvasWidth = canvasTransform.rect.width;
        float center = 0f;
        float step = canvasWidth / 5;
        float[] xPos = new float[numCards];

        int centerInd = (int) Math.Floor((double) (numCards / 2));
        if (numCards % 2 == 0)
        {
            xPos[centerInd] = center + (step / 2);
            xPos[centerInd - 1] = center - (step / 2);

            for (int i = centerInd + 1; i < numCards; i++)
            {
                xPos[i] = xPos[i - 1] + step;
            }

            for (int i = centerInd - 2; i >= 0; i--)
            {
                xPos[i] = xPos[i + 1] - step;
            }
        }
        else
        {
            xPos[centerInd] = center;

            for (int i = centerInd + 1; i < numCards; i++)
            {
                xPos[i] = xPos[i - 1] + step;
            }

            for (int i = centerInd - 1; i >= 0; i--)
            {
                xPos[i] = xPos[i + 1] - step;
            }
        }

        for (int i = 0; i < xPos.Length; i++)
        {
            float x = xPos[i];
            GameObject cardPrefab = cardPrefabs[i];

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

        investigatePanelAnimator.SetBool("reverseReady", true);
        investigatePanelAnimator.SetBool("ready", false);

        backButton.gameObject.SetActive(false);
        thoughtText.text = "What gift would really give my next victim a scare...?";
    }
}
