using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSFX : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true && Reputation.toggleSfx == true)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
