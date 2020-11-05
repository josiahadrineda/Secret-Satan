using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;

namespace cakeslice
{
    public class Toggle : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            GetComponent<Outline>().enabled = false;
        }

        void OnMouseOver()
        {
            GetComponent<Outline>().enabled = true;
        }

        void OnMouseExit()
        {
            GetComponent<Outline>().enabled = false;
        }
    }
}