using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    public float speed = 1.5f;
    bool flip = false;
    bool grow = false;

    int numClicks = 0;

    void OnMouseOver()
    {
        flip = true;
    }

    void OnMouseExit()
    {
        if (numClicks == 0)
        {
            flip = false;
        }
        else
        {
            flip = true;
        }
    }

    void OnMouseDown()
    {
        flip = true;
        grow = true;

        numClicks++;
        if (numClicks == 2)
        {
            numClicks = 0;
            flip = false;
            grow = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform cardTransform = GetComponent<RectTransform>();
        if (flip)
        {
            Quaternion newPos = Quaternion.Euler(cardTransform.rotation.x, 0, cardTransform.rotation.z);
            cardTransform.rotation = Quaternion.Slerp(cardTransform.rotation, newPos, speed * Time.deltaTime);
        }
        else
        {
            Quaternion newPos = Quaternion.Euler(cardTransform.rotation.x, 180, cardTransform.rotation.z);
            cardTransform.rotation = Quaternion.Slerp(cardTransform.rotation, newPos, speed * Time.deltaTime);
        }

        if (grow)
        {
            cardTransform.localScale = Vector3.Lerp(cardTransform.localScale, new Vector3(0.6f, 0.6f, 1), speed * Time.deltaTime);
        }
        else
        {
            cardTransform.localScale = Vector3.Lerp(cardTransform.localScale, new Vector3(0.4f, 0.4f, 1), speed * Time.deltaTime);
        }
    }
}
