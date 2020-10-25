using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace cakeslice
{
    public class Toggle : MonoBehaviour
    {
        public GameObject item;
        public Text hoveredItemText;
        public Text thoughtText;

        public Button yesButton;
        public Button noButton;

        public GameObject[] layers = new GameObject[5];

        // Use this for initialization
        void Start()
        {
            GetComponent<Outline>().enabled = false;
        }

        void OnMouseOver()
        {
            GetComponent<Outline>().enabled = true;
            hoveredItemText.text = item.name.ToString();
        }

        void OnMouseExit()
        {
            GetComponent<Outline>().enabled = false;
            hoveredItemText.text = "Pick a gift.";
        }

        void OnMouseDown()
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
            }
        }
    }
}