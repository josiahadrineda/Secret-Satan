using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NextButtonCollider : MonoBehaviour
{
    public Events events;
    public Sprite buttonDown;
    public Sprite buttonUp;

    void OnMouseDown()
    {
        GetComponent<Image>().sprite = buttonDown;
    }

    void OnMouseUp()
    {
        GetComponent<Image>().sprite = buttonUp;
        events.IncrementNextCount();
    }
}
