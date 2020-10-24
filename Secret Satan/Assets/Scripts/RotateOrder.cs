using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOrder : MonoBehaviour
{
    public GameObject card;
    public Canvas frontCoverCanvas;

    // Update is called once per frame
    void Update()
    {
        float yRot = card.transform.rotation.eulerAngles.y;
        
        if (90 < yRot && yRot < 270)
        {
            frontCoverCanvas.sortingOrder = 2;
        }
        else
        {
            frontCoverCanvas.sortingOrder = 0;
        }
    }
}
