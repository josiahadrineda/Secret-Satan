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
    }
}