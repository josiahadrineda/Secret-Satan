using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ValidateSelection : MonoBehaviour
{
    public GameObject correctPanel;
    public GameObject deathPanel;
    public GameObject finPanel;

    public GameObject[] layers = new GameObject[5];

    public GameObject optionsTrigger;
    public Button optionsButton;
    public Button quitButton;

    public Text thoughtText;

    // Use this for initialization
    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Reputation.isLastLevel = false;
            Reputation.answer = GameObject.Find("Jack in the Box");
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Reputation.isLastLevel = false;
            Reputation.answer = GameObject.Find("Tombstones");
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Reputation.isLastLevel = false;
            Reputation.answer = GameObject.Find("Tarantula");
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            Reputation.isLastLevel = false;
            Reputation.answer = GameObject.Find("Trash Bin");
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            Reputation.isLastLevel = true;
            Reputation.answer = GameObject.Find("Cassette Player");
        }
    }

    public void CheckAnswer()
    {
        if (Reputation.selection != Reputation.answer)
        {
            Reputation.reputation--;

            if (Reputation.reputation == 0)
            {
                deathPanel.gameObject.SetActive(true);
                Invoke("DisableAll", 0);
            }
            else
            {
                thoughtText.text = "Hmm... it seems that your gift wasn't scary enough...";
            }
        }
        else
        {
            if (Reputation.isLastLevel)
            {
                finPanel.gameObject.SetActive(true);
                Invoke("DisableAll", 0);
            }
            else
            {
                correctPanel.gameObject.SetActive(true);
                Invoke("DisableAll", 0);
            }
        }
    }

    void DisableAll()
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

        optionsTrigger.GetComponent<BoxCollider2D>().enabled = false;
        optionsButton.interactable = false;
        quitButton.interactable = false;
    }
}
