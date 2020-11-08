using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOrder : MonoBehaviour
{
    public GameObject card;
    public Canvas frontCoverCanvas;

    void Update()
    {
        float yRot = card.transform.rotation.eulerAngles.y;
        
        if (90 < yRot && yRot < 270)
        {
            frontCoverCanvas.overrideSorting = true;
        }
        else
        {
            frontCoverCanvas.overrideSorting = false;
        }
    }
}
